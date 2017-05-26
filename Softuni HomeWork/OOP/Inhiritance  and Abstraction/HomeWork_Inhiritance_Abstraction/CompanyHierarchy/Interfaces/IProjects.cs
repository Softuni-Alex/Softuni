using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Interfaces
{
    using Enums;
    internal interface IProject
    {
        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the project start date.
        /// </summary>
        DateTime ProjectStartDate { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        string Details { get; set; }

        /// <summary>
        /// Gets the project state.
        /// </summary>
        ProjectState ProjectState { get; }
    }
}
