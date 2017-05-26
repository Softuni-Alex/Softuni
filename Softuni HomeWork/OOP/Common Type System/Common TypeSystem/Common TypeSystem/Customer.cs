namespace Common_TypeSystem
{

    using System;
    using System.Collections.Generic;

    class Customer : IComparable<Customer>, ICloneable
    {
        public Customer(string firstName, string middleName, string lastName, string id
            , string permanentAddress, string mobilePhone, string email
            , List<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private List<Payment> payments;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Utilities.ValidateString(value, "First name");
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                Utilities.ValidateString(value, "Middle name");
                this.middleName = value;
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
                Utilities.ValidateString(value, "Last name");
                this.lastName = value;
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                Utilities.ValidateString(value, "ID");
                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            set
            {
                Utilities.ValidateString(value, "Permanent address");
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                Utilities.ValidateString(value, "Mobile phone");
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                Utilities.ValidateString(value, "E-mail");
                this.email = value;
            }
        }

        public List<Payment> Payments
        {
            get
            {
                return this.payments;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Payments", "Value cannot be null");
                }
                this.payments = value;
            }
        }

        public CustomerType CustomerType { get; set; }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            if (customer == null)
            {
                return false;
            }
            if (!Object.Equals(this.ID, customer.ID))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.PermanentAddress.GetHashCode();
        }

        public override string ToString()
        {
            string info = "Customer info:\n----\nFirst name: " + this.FirstName
                + "\nMiddle name: " + this.MiddleName
                + "\nLast name: " + this.LastName
                + "\nID: " + this.ID
                + "\nCustomer type: " + this.CustomerType
                + "\nPermanent address: " + this.PermanentAddress
                + "\nMobile phone: " + this.MobilePhone
                + "\nEmail: " + this.Email
                + "\nPayments:\n" + string.Join("\n", this.Payments);
            return info;
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return Customer.Equals(customer1, customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(Customer.Equals(customer1, customer2));
        }

        public int CompareTo(Customer otherCustomer)
        {
            string names = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string otherCustomerNames = otherCustomer.FirstName + " "
                + otherCustomer.MiddleName + " " + otherCustomer.LastName;

            if (string.Compare(names, otherCustomerNames) > 0)
            {
                return 1;
            }
            if (string.Compare(names, otherCustomerNames) == 0)
            {
                if (string.Compare(this.ID, otherCustomer.ID) == 0)
                {
                    return 0;
                }
                else if (string.Compare(this.ID, otherCustomer.ID) > 0)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }

        public object Clone()
        {
            return this.CloneCustomer();
        }

        public Customer CloneCustomer()
        {
            List<Payment> clonedPayments = this.Payments;
            for (int i = 0; i < clonedPayments.Count; i++)
            {
                clonedPayments[i] = (Payment)clonedPayments[i].Clone();
            }
            return new Customer(this.FirstName, this.MiddleName, this.LastName
                , this.ID, this.PermanentAddress, this.MobilePhone, this.Email
                , clonedPayments, this.CustomerType);
        }
    }

}
