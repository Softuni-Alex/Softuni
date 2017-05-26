using Empires.Enum;
using System;

namespace Empires.Object
{
    public class Resource
    {
        private int quantity;
        public Resource(ResourceType resourceType, int quantity)
        {
            this.ResourceType = resourceType;
            this.Quantity = quantity;

        }
        public ResourceType ResourceType
        {
            get;
            private set;
        }
        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Resources produced value should be non-negative!");
                this.quantity = value;
            }
        }
        public string ID
        {
            get { return this.ResourceType.ToString(); }
        }
    }
}
