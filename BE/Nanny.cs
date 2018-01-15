using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Nanny
    {
        public Nanny() { myChildren = new List<Child>(); }
        public int ID { get; set; }
        public Name name { get; set; }
        public DateTime birthday { get; set; }
        public int cellPhone { get; set; }
        public string address { get; set; }
        public bool elevator { get; set; }
        public int floor { get; set; }
        public int Expirence { get; set; }
        public int MaxChildren { get; set; }
        public int MinAge { get; set; }//in mounths
        public int MaxAge { get; set; }//in mounths
        public int peopleThatRating { get; set; }//another people update it
        public int Stars { get; set; }
        /// <summary>
        /// a list of children I take care of
        /// </summary>
        public List<Child> myChildren;
        public bool PerHour {  get; set; }

        private double sallaryPerHour;
        public double SallaryPerHour
        {
            get { return sallaryPerHour; }
            set
            {
                if (PerHour)
                    sallaryPerHour = value;
            }
        }
        public double SallaryPerMonth  {  get; set; }

        WeeklyHours WH;
        public WeeklyHours wh
        {
            get { return WH; }
            set
            {
                WH = value;
                for (int i = 0; i < 6; i++)
                {
                    if (WH.WorkHours[i].sumMinuts > 0)
                        WH.DayThatIWork[i] = true;
                    else
                        WH.DayThatIWork[i] = false;
                }
            }
        }

        public bool DaysOff { get; set; }//if the Days off base of ha'tmat
        string recommendations;
        public string Recommendations
        {
            get { return recommendations; }
            set
            {
                recommendations += value;
                numberRecommendations++;
            }
        }

        public int numberRecommendations = 0;


        public override string ToString()
        {
            return this.ToStringProperty();
        }

        public string print()
        {
            string s = "";
            s += String.Format("CellPhone: 0" + cellPhone) + "\n";
            s += String.Format("Age: " + (DateTime.Now.Year - birthday.Year)) + "\n";
            s += String.Format("Expirence " + Expirence + " years") + "\n";
            s += String.Format("Accepts Children from " + MinAge + " months to " + MaxAge + " months") + "\n";
            s += String.Format("Maximum number of children: " + MaxChildren) + "\n";

            return s;
        }

    }
}