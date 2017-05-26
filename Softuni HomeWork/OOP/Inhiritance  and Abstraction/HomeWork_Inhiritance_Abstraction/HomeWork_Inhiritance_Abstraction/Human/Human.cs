using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Inhiritance_Abstraction.Human
{
   public abstract class Human
    {

        protected string firstName;
        protected string lastName;



        public Human(string firstName,string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

       public string FirstName
        {
           get
            {
               return this.firstName;
           }
           set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be null or empty!");
                }
                this.firstName = value;
            }
        }
        public string LastName
       {
            get
           {
               return this.lastName;
           }
            set
           {
               if (string.IsNullOrEmpty(value))
               {
                   throw new ArgumentNullException("The last name cannot be null or empty!");
               }
               this.lastName = value;
           }
       }

    }
}
