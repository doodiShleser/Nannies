using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class WeeklyHours
    {
        public WeeklyHours() { }

        public WeeklyHours(DayWork[] hours)
        {
            if (hours.Length == 6)
            {
                workHours = hours;
                for (int i = 0; i < 6; i++)
                {
                    workHours[i].sumMinuts = workHours[i].end.sumMinuts() - workHours[i].begin.sumMinuts();
                    sumOfHours += workHours[i].sumMinuts;
                }
                sumOfHours /= 60;
                dayThatIWork = new bool[6];
            }
            else
                throw new Exception("missing Days Details Accepting");
        }
        private DayWork[] workHours { get; set; }
        public DayWork[] WorkHours
        {

            get { return workHours; }
        }
        public double sumOfHours = 0;
        /// an Array that contain the work Hours of Nanny,
        /// the row[0] for begin Hour and row[1] for ending. the collomns for days  
        /// </summary>
        private bool[] dayThatIWork;
        public bool[] DayThatIWork
        {
            get { return dayThatIWork; }
        }


        public string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

        public override string ToString()
        {
            string str = "\n" + string.Format("{0,18} {1,13}{2,13}", "Day", "begin Hour", "end Hour") + "\n";
            for (int i = 1; i <= 6; i++)
                str += string.Format("{0,18} {1,15} {2,15}", days[i - 1], workHours[i - 1].begin, workHours[i - 1].end) + "\n";
            return str;
        }
        public bool Possible(WeeklyHours w)
        {
            for (int i = 0; i < 6; i++)
                if (w.workHours[i].sumMinuts > 0 && !WorkHours[i].contain(w.WorkHours[i]))
                    return false;
            return true;
        }


    }
}