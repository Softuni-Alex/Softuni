using Empires.Enum;

namespace Empires.Object
{
    public class Barracks : Building
    {
        public Barracks() : base(
           new Resource(ResourceType.Steel, 10), 3,
           new Swordsman(), 4)
        {
        }
    }
}
