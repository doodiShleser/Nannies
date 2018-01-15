using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int code { get; set; }//number of contract, of 8 digits
        public int idNanny { get; set; }
        public Name NameNanny { get; set; }
        public int idChild { get; set; }
        public bool IntroductoryMeeting { get; set; }//if such an arrangment was made
        public bool signed { get; set; }///if A contract of employment was signed
                                        /// <summary>
                                        ///if sallary per Month is true else false
                                        /// </summary>
        public bool PMorPH { get; set; }
        public double SallaryPerHour { get; set; }
        private double sallaryPerMonth;
        public double SallaryPerMonth
        {
            get
            {
                return System.Math.Round(sallaryPerMonth, 2);
            }
            set
            {
                sallaryPerMonth = value;
            }
        }
        public DateTime beginDeal;
        public DateTime endDeal;
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
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}