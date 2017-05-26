using TankManufacturer.Units;

namespace FactoryMethod.Units
{
    public class GermanFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank("Tiger", 4.5, 120);
        }
    }
}
