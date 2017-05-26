using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class Version:System.Attribute
    {

        /// <summary>
        /// FIELDS
        /// </summary>
        private int major;
        private int minor;

        /// <summary>
        /// CONSTURCTOR
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        public Version(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        /// <summary>
        /// PROPERTIES
        /// </summary>
        public int Minor
        {
            get { return this.minor; }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be a positive or 0");
                }
                this.minor = value;
            }
        }

        public int Major
        {
            get { return this.major; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be a positive number or 0");
                }
                this.major = value;
            }
        }
    }
}
