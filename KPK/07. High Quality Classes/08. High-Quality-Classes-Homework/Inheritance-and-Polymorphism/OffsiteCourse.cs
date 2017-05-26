using System;
using System.Collections.Generic;
using System.Text;
using InheritanceAndPolymorphism.Interfaces;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string _town;

        public OffsiteCourse(string courseName, string teacherName, string town)
            : base(courseName, teacherName)
        {
            this.Town = town;
        }

        public string Town
        {
            get { return this._town; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(_town), "Town name can not be null or empty space!");
                }
                this._town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder offsiteCourse = new StringBuilder(base.ToString());
            offsiteCourse.Length -= 2;
            offsiteCourse.AppendFormat("; Town = {0}", this.Town);
            offsiteCourse.Append(" }");

            return offsiteCourse.ToString();
        }
    }
}