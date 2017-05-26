using TankManufacturer.Units;

namespace FactoryMethod.Units
{
    public class RussianFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank("T 34", 3.3f, 75);
        }
    }
}
