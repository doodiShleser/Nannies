using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
namespace BL
{
    public class MorBL
    {
        protected MorBL() { }
        protected static MorBL BLinstance = null;
        public static MorBL GetInstance()
        {
            if (BLinstance == null)
                BLinstance = new MorBL();
            return BLinstance;
        }
        static IBL instance = BL_imp.GetInstance();//singelton

        public bool isExist(string id)
        {
            return (instance.getNanny().Exists(x => x.ID == int.Parse(id)) || instance.getMother().Exists(x => x.ID == int.Parse(id)));
        }

        public List<Nanny> FiveMostAppropriateNannies(List<Nanny> n, Mother m)
        {
            List<Nanny> t = n;
            List<Nanny> Five = new List<Nanny>();
            List<KeyValuePair<Nanny, int>> temp = BLSorting.GetInstance().sortBySuitableDays(t, m);
            for (int i = 0; i < 5; i++)
            {
                if (i < temp.Count)
                    Five.Add(temp[i].Key);
            }
            return Five;
        }
        public List<Nanny> accordingTHAMAT(List<Nanny> n)
        {
            List<Nanny> temp = n;
            List<Nanny> t = new List<Nanny>();
            foreach (Nanny item in temp)
                if (item.DaysOff)
                    t.Add(item);
            return temp;
        }
        /// <summary>
        /// return list of children thay don't have a nanny
        /// </summary>
        public List<Child> NoNanny()
        {
            List<Contract> temp = instance.getContract();
            List<Child> t = new List<Child>();
            List<Child> t2 = instance.getChild();
            foreach (Child c in t2)
            {
                foreach (Contract item in temp)
                    if (c.ID == item.idChild)
                        t.Add(c);
            }
            foreach (Child item in t)
                t2.Remove(item);
            return t2;
        }

        public List<Contract> conditionListReturned(Func<Contract, bool> anyif)
        {
            List<Contract> temp = instance.getContract();
            List<Contract> t = new List<Contract>();
            foreach (Contract item in temp)
                if (anyif(item))
                    t.Add(item);
            return t;
        }
        public int conditionIntReturned(Func<Contract, bool> anyif)
        {
            int count = 0;
            List<Contract> temp = instance.getContract();
            foreach (Contract item in temp)
                if (anyif(item))
                    count++;
            return count;
        }




        public List<Nanny> relevanceNannies(List<Nanny> NanList, Mother m)
        {
            List<Nanny> suitable = new List<Nanny>();
            List<Nanny> temp = new List<Nanny>();
            temp = NanList;
            List<KeyValuePair<Nanny, int>> t = BLSorting.GetInstance().sortBySuitableDays(temp, m);
            int i = t.Count - 1;
            while (i > 0 && t[i].Value >= 0)
            {
                suitable.Add(t[i].Key);
                i--;
            }
            return suitable;
        }
        public List<Nanny> freeSpace(List<Nanny> NanList)
        {
            List<Nanny> freeSpace = new List<Nanny>();
            List<Nanny> t = new List<Nanny>();
            t = NanList;
            foreach (Nanny item in t)
                if (item.myChildren.Count < item.MaxChildren)
                    freeSpace.Add(item);
            return freeSpace;
        }
        public List<Nanny> Elevator(List<Nanny> NanList)
        {
            List<Nanny> elevator = new List<Nanny>();
            foreach (Nanny item in NanList)
                if (item.elevator)
                    elevator.Add(item);
            return elevator;
        }
        public List<Nanny> DaylyPayment(List<Nanny> NanList)
        {
            List<Nanny> daylyPayment = new List<Nanny>();
            foreach (Nanny item in NanList)
                if (item.PerHour)
                    daylyPayment.Add(item);
            return daylyPayment;
        }
    }
}