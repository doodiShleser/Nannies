using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Name
    {
        public Name(string f = "", string l = "") { FirstName = f; LastName = l; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public override string ToString()
        {
            return String.Format(FirstName + " " +LastName);
        }
        public bool Compare(Name n)
        {
            return (FirstName == n.FirstName && LastName == n.LastName);
        }
    }

}