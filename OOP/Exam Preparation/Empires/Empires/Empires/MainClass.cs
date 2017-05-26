
namespace Empires
{
    using Empires.Engine;
    using Empires.Interface;
    using Empires.UI;

    public class MainClass
    {
        static void Main()
        {
            IReader renderer = new ConsoleRenderer();
            IInputHandler reader = new ConsoleReader();
            BaseDB db = new BaseDB();

            MainEngine engine = new MainEngine(renderer, reader, db);
            engine.Run();

        }
    }
}
