using EnvironmentSystem.Models.Objects;

namespace EnvironmentSystem
{
    using EnvironmentSystem.Core;

    public class EnvironmentSystemMain
    {
        private const int WorldWidth = 50;
        private const int WorldHeight = 30;

        static void Main()
        {
            var objectGenerator = new ObjectGenerator(WorldWidth, WorldHeight);
            var consoleRenderer = new ConsoleRenderer(WorldWidth, WorldHeight);
            var collisionHandler = new CollisionHandler(WorldWidth, WorldHeight);

            var engine = new Engine(WorldWidth,
                WorldHeight,
                objectGenerator,
                collisionHandler,
                consoleRenderer);

            engine.Run();
        }
    }
}
