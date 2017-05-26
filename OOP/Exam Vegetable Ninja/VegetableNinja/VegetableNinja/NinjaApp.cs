namespace VegetableNinja
{
    using Interfaces;
    using UI;

    public class NinjaApp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine.Engine engine = new Engine.Engine(reader, writer);

            engine.Run();
        }
    }
}