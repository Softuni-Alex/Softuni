using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Interfaces
{
    using Enums;
    interface IEmployee
    {

        decimal Salary { get; set; }

       Departments Department { get; set; }

    }
}
