using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {

        public int ID { get; set; }
        public int idMother { get; set; }
        public DateTime birthday;
        public string FirstName { get; set; }
        public bool special { get; set; }
        public string specialNeeds { get; set; }
        public int stars;
        public string recomendationsNanny { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}