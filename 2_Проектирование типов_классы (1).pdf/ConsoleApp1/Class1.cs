using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_partial
{
    public partial class Set
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void PrintFullName()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }
}
