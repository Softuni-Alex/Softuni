using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Company
{
    using Interfaces;
    using Enums;
    class RegularEmployee : Employee
    {

        protected RegularEmployee(int id,string firstName,string lastName,Departments department,decimal salary)
            :base(id,firstName,lastName,salary,department)
	{

	}

    }
}
