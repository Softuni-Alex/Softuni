using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Company
{

    using Interfaces;
    using Enums;
    class SalesEmployee :RegularEmployee
    {
        public SalesEmployee(int id, string firstName, string lastName, Departments department, decimal salary, List<ISales> sales)
            : base(id, firstName, lastName, department, salary)
        {
            this.Sales = sales;
        }

        public SalesEmployee(int id, string firstName, string lastName, Departments department, decimal salary, ISales sale)
            : this(id, firstName, lastName, department, salary, new List<ISales>() { sale })
        {
        }

        public List<ISales> Sales { get; private set; }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("Role: Sales Employee\n");
            result += string.Format("Sales made: {0}\n", this.Sales.Count);
            return result;
        }

    }
}
