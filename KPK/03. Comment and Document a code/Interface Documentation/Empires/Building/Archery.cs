using Empires.Enum;

namespace Empires.Object
{
    public class Archery : Building
    {
        public Archery()
            : base(
            new Resource(ResourceType.Gold, 5), 2,
            new Archer(), 3)
        {
        }
    }
}
