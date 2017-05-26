using TankManufacturer.Units;

namespace FactoryMethod.Units
{
    public class AmericanFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank("M1 Abrams", 5.4f, 120);
        }
    }
}
