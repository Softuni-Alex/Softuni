using BlobsOOP.Engine;
using BlobsOOP.Engine.Factories;
using BlobsOOP.Interfaces;
using BlobsOOP.UI;
using System.Collections.Generic;

namespace BlobsOOP
{
    public class BlobsApp
    {
        public static void Main()
        {
            var engine = new Engine.Engine(new BlobFactory(), new AttackFactory(), new BehaviorFactory(), new ConsoleInputReader(), new ConsoleOutputWriter(), new BlobData(new List<IBlob>()));

            engine.Run();
        }
    }
}