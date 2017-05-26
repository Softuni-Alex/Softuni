using RPGGame.Engine;
using RPGGame.Interfaces;
using RPGGame.UI;

namespace RPGGame
{
    class RpgGameApp
    {
        static void Main()
        {

            IRenderer renderer = new ConsoleRenderer();
            IInputReader reader = new ConsoleInputReader();

            SuperEngine engine = new SuperEngine(reader, renderer);

            engine.Run();

        }
    }
}
