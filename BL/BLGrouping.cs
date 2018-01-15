using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public class BLGrouping
    {
        protected BLGrouping() { }
        protected static BLGrouping BLinstance = null;
        public static BLGrouping GetInstance()
        {
            if (BLinstance == null)
                BLinstance = new BLGrouping();
            return BLinstance;
        }
        static IBL instance = BL_imp.GetInstance();//singelton

        #region grouping functions
        public List<Nanny>[] groupingByAge(List<Nanny> nan, bool min, bool sort = false)
        {
            List<Nanny> t = nan;

            //determinate size of array according to max min/max age property of nanny
            int max = 0;
            if (min)
            {
                foreach (Nanny item in t)
                    if (item.MinAge > max)
                        max = item.MinAge;
            }
            else
            {
                foreach (Nanny item in t)
                    if (item.MaxAge > max)
                        max = item.MaxAge;
            }
            List<Nanny>[] myGroup = new List<Nanny>[max + 1];
            for (int i = 0; i < myGroup.Length; i++)
                myGroup[i] = new List<Nanny>();
            if (sort)
            {
                if (min)
                {
                    var nannyGroups = from nanny in t
                                      orderby nanny.MaxAge
                                      group nanny by nanny.MinAge into g
                                      select new { age = g.Key, nanny = g };
                    foreach (var item in nannyGroups)
                    {
                        var my = item.nanny.ToList();
                        foreach (Nanny n in my)
                            myGroup[item.age].Add(n);
                    }
                }
                else
                {
                    var nannyGroups = from nanny in t
                                      orderby nanny.MinAge
                                      group nanny by nanny.MaxAge into g
                                      select new { age = g.Key, nanny = g };
                    foreach (var item in nannyGroups)
                    {
                        var my = item.nanny.ToList();
                        foreach (Nanny n in my)
                            myGroup[item.age].Add(n);
                    }
                }
            }
            else
            {
                if (min)
                {
                    var nannyGroups = from nanny in t
                                      group nanny by nanny.MinAge into g
                                      select new { age = g.Key, nanny = g };
                    foreach (var item in nannyGroups)
                    {
                        var my = item.nanny.ToList();
                        foreach (Nanny n in my)
                            myGroup[item.age].Add(n);
                    }
                }
                else
                {
                    var nannyGroups = from nanny in t
                                      group nanny by nanny.MaxAge into g
                                      select new { age = g.Key, nanny = g };
                    foreach (var item in nannyGroups)
                    {
                        var my = item.nanny.ToList();
                        foreach (Nanny n in my)
                            myGroup[item.age].Add(n);
                    }
                }
            }

            return myGroup;
        }
        public List<Contract>[] groupByDistance(Mother m, bool sort = false)
        {
            if (sort)
            {
                List<Contract> t = instance.getContract();
                int distance = 0;
                foreach (Contract item in t)
                    if (BL_imp.GetInstance().CalculateDistance(m.address, instance.getNanny().Find(x => x.ID == item.idNanny).address) > distance)
                        distance = BL_imp.GetInstance().CalculateDistance(m.address, instance.getNanny().Find(x => x.ID == item.idNanny).address);
                List<Contract>[] myGroup = new List<Contract>[((distance / 1000) + 1) / 4];
                for (int i = 0; i < myGroup.Length; i++)
                    myGroup[i] = new List<Contract>();
                var ContractGroups = from contract in t
                                     orderby BL_imp.GetInstance().CalculateDistance(m.address, instance.getNanny().Find(x => x.ID == contract.idNanny).address)
                                     group contract by BL_imp.GetInstance().CalculateDistance(m.address, instance.getNanny().Find(x => x.ID == contract.idNanny).address) / 5000 into g
                                     select new { distance = g.Key, contract = g };
                //foreach (var item in ContractGroups)
                //    myGroup[item.distance].Add(item.contract.Single());
                foreach (var item in ContractGroups)
                {
                    var my = item.contract.ToList();
                    foreach (Contract c in my)
                        myGroup[item.distance].Add(c);
                }
                return myGroup;
            }
            else
            {
                List<Contract> t = instance.getContract();
                int distance = 0;
                foreach (Contract item in t)
                    if (BL_imp.GetInstance().CalculateDistance(m.address, instance.getNanny().Find(x => x.ID == item.idNanny).address) > distance)
                        distance = BL_imp.GetInstance().CalculateDistance(m.address, instance.getNanny().Find(x => x.ID == item.idNanny).address);
                List<Contract>[] myGroup = new List<Contract>[(distance / 1000 + 1) / 4];
                for (int i = 0; i < myGroup.Length; i++)
                    myGroup[i] = new List<Contract>();
                var ContractGroups = from contract in t
                                     group contract by BL_imp.GetInstance().CalculateDistance(m.address, instance.getNanny().Find(x => x.ID == contract.idNanny).address) / 5000 into g
                                     select new { distance = g.Key, contract = g };
                foreach (var item in ContractGroups)
                {
                    var my = item.contract.ToList();
                    foreach (Contract c in my)
                        myGroup[item.distance].Add(c);
                }
                return myGroup;
            }
        }
        #endregion grouping functions
    }
}