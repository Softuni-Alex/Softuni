using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Interfaces
{
    interface IPerson
    {

         int ID { get; set; }
        string  FirstName { get; set; }

        string LastName { get; set; }

    }
}
