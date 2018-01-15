using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Threading;

namespace BL
{
    public class BLSorting
    {
        protected BLSorting() { }
        protected static BLSorting BLinstance = null;
        public static BLSorting GetInstance()
        {
            if (BLinstance == null)
                BLinstance = new BLSorting();
            return BLinstance;
        }
        static IBL instance = BL_imp.GetInstance();//singelton
        #region sorting

        public List<KeyValuePair<Nanny, int>> sortBySuitableDays(List<Nanny> n, Mother m)
        {
            int val = 0;
            List<Nanny> temp = n;
            Dictionary<Nanny, int> myDict = new Dictionary<Nanny, int>();
            foreach (Nanny item in temp)
            {
                for (int i = 0; i < item.wh.WorkHours.Length; i++)
                    if (item.wh.WorkHours[i].Fixed(m.wh.WorkHours[i]) <= 0)
                        val++;
                myDict.Add(item, val);
                val = 0;
            }
            List<KeyValuePair<Nanny, int>> myList = myDict.ToList();
            myList.Sort(delegate (KeyValuePair<Nanny, int> pair1, KeyValuePair<Nanny, int> pair2)
            { return pair1.Value.CompareTo(pair2.Value); });
            return myList;
        }
        public List<Nanny> sortByPrice(List<Nanny> n)
        {
            List<Nanny> price = n;
            price.Sort(delegate (Nanny nan1, Nanny nan2) { return nan1.SallaryPerMonth.CompareTo(nan2.SallaryPerMonth); });
            return price;
        }
        public List<KeyValuePair<Nanny, int>> sortByDistance(List<Nanny> n, Mother m)
        {
            List<Nanny> temp = instance.getNanny();
            List<Nanny> best = new List<Nanny>();
            Dictionary<Nanny, int> myDict = new Dictionary<Nanny, int>();
            foreach (Nanny item in temp)
                new Thread(() =>
                myDict.Add(item, BL_imp.GetInstance().CalculateDistance(item.address, m.address))
                ).Start();

            List<KeyValuePair<Nanny, int>> myList = myDict.ToList();
            myList.Sort(delegate (KeyValuePair<Nanny, int> pair1, KeyValuePair<Nanny, int> pair2)
            { return pair1.Value.CompareTo(pair2.Value); });
            return myList;
        }

        public List<Nanny> sortByRating(List<Nanny> n)
        {
            List<Nanny> rating = n;
            int r1, r2;
            rating.Sort(delegate (Nanny nan1, Nanny nan2) 
            {
                if (nan1.peopleThatRating == 0)
                    r1 = 0;
                else
                    r1 = nan1.Stars / nan1.peopleThatRating;
                if (nan2.peopleThatRating == 0)
                    r2 = 0;
                else
                    r2 = nan2.Stars / nan2.peopleThatRating;
                return (r2).CompareTo(r1);
            });
            return rating;
        }
        #endregion sorting
    }
}