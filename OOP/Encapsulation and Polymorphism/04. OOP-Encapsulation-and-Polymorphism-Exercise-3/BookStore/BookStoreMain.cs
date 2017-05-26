using BookStore.UI;

namespace BookStore
{
    using Engine;

    public class BookStoreMain
    {
        public static void Main()
        {

            //  FileRenderer fileRenderer = new FileRenderer();

            ConsoleRenderer renderer = new ConsoleRenderer();
            ConsoleInputHandler inputHandler = new ConsoleInputHandler();

            BookStoreEngine engine = new BookStoreEngine(renderer, inputHandler);

            engine.Run();
        }
    }
}
