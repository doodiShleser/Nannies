using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Mother
    {
        public int ID { get; set; }
        public Name name;
        public int cellPhone { get; set; }
        public string address { get; set; }
        public string location { get; set; }//a landmark address for searching around
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
        public string remarks { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }

        public string print()
        {
            string s = "";
            s += String.Format("CellPhone: 0" + cellPhone) + "\n";




            return s;
        }
    }
}