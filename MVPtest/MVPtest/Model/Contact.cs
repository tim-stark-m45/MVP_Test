using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPtest.Model
{
    [Serializable]
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Surname}";
        }
    }
}
