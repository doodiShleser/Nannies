using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Clock
    {
        public int? hour { get; set; }
        public int? minut { get; set; }
        private bool isValid = false;

        public Clock(Clock other)
        {
            hour = other.hour;
            minut = other.minut;
            isValid = other.isValid;
        }

        public Clock(int? h = null, int? m = null)
        {
            if (h >= 0 && h < 24 && m >= 0 && m < 60)
            {
                hour = h;
                minut = m;
                isValid = true;
            }
        }
        /// <summary>
        /// use to calculate how much hours Nanny works
        /// </summary>
        /// <returns>presentation of time in minuts of a day</returns>
        public int sumMinuts()
        {
            if (isValid)
                return (int)(hour * 60 + minut);
            else
                return 0;
        }
        public override string ToString()
        {
            string result = "";
            if (isValid)
            {
                if (hour == 0)
                    result += "00:";
                else if (minut < 10)
                    result += "0" + hour.ToString() + ":";
                else result += hour.ToString() + ":";

                if (minut == 0)
                    result += "00";
                else if (minut < 10)
                    result += "0" + minut.ToString();
                else result += minut.ToString();
            }
            else
                result += "--:--";
            return result;
        }
        public Clock ClockReturned()
        {
            return new Clock(hour, minut);
        }
        static public Clock ConvertToClock(string other)
        {
            if (other.ElementAt(0) != '-')
                return new Clock(int.Parse(other.Substring(0, other.IndexOf(':'))), int.Parse(other.Substring(other.IndexOf(':') + 1)));
            else return new Clock();
        }
    }
}