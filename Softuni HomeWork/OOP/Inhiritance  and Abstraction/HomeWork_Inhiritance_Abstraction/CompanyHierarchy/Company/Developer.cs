using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Company
{
    using Interfaces;
    using Enums;
    using Projects;
    class Developer:RegularEmployee
    {

        public Developer(int id, string firstName, string lastName, Departments department, decimal salary, List<IProject> projects)
            : base(id, firstName, lastName, department, salary)
        {
            this.Projects = projects;
        }
        public Developer(int id, string firstName, string lastName, Departments department, decimal salary, IProject project)
            : this(id, firstName, lastName, department, salary, new List<IProject>() { project })
        {
        }

        public List<IProject> Projects { get; private set; }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("Role: Developer\n");
            result += string.Format("Projects: ");

            List<string> projectNames = new List<string>();
            foreach (var proj in this.Projects)
            {
                projectNames.Add(proj.ProjectName);
            }

            result += string.Join(", ", projectNames) + "\n";

            return result;
        }

    }
}
