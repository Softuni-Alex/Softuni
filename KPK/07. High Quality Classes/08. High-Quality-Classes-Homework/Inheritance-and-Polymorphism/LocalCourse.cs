using System;
using System.Collections.Generic;
using System.Text;
using InheritanceAndPolymorphism.Interfaces;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string _lab;

        public LocalCourse(string courseName, string teacherName, string lab)
            : base(courseName, teacherName)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this._lab; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(_lab), "Lab name can not be null or empty space!");
                }
                this._lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder localCourse = new StringBuilder(base.ToString());
            localCourse.Length -= 2;
            localCourse.AppendFormat("; Lab = {0}", this.Lab);
            localCourse.Append(" }");

            return localCourse.ToString();
        }
    }
}