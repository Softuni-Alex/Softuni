using System;
using Empires.CustomException;

namespace Empires.Object
{
    public abstract class Building
    {
        private int resourceCycle;
        private int unitCycle;
        private int counter;

        public Building(Resource resource, int resourceCycle, Unit unit, int unitCycle)
        {
            this.Resource = resource;
            this.ResourceCycle = resourceCycle;
            this.Unit = unit;
            this.UnitCycle = unitCycle;
            this.counter = 0;
        }

        private int ResourceCycle
        {
            get { return this.resourceCycle; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Resource cycle number must be positive!");
                else
                    this.resourceCycle = value;
            }
        }

        private int UnitCycle
        {
            get { return this.unitCycle; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Unit cycle number must be positive!");
                else
                    this.unitCycle = value;
            }
        }

        private Unit Unit { get; set; }
        private Resource Resource { get; set; }

        public string ID
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public void Tick()
        {
            this.counter++;
        }

        private int NextUnit
        //How many turns until the next unit is produced
        {
            get
            {
                return this.unitCycle - this.counter % this.UnitCycle;
            }
        }

        private int NextResource
        //How many turns until the next resource is produced
        {
            get
            {
                return this.ResourceCycle - this.counter % this.ResourceCycle;
            }
        }

        public Unit GetUnit()
        //Produce a unit if ready
        {
            if (this.counter != 0 && this.NextUnit == this.unitCycle)
                return this.Unit;
            else
                throw new UnitException();
        }

        public Resource GetResource()
        //Produce a resource if ready
        {
            if (this.counter != 0 && this.NextResource == this.ResourceCycle)
                return this.Resource;
            else
                throw new ResourceException();
        }

        public override string ToString()
        {
            return
                "--" +
                this.ID +
                ": " +
                this.counter +
                " turns (" +
                this.NextUnit +
                " turns until " +
                this.Unit.ID +
                ", " +
                this.NextResource +
                " turns until " +
                this.Resource.ID +
                ")";
        }
    }
}
