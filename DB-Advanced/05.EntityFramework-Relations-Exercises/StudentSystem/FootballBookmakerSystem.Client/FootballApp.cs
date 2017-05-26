using FootballBookmakerSystem.Data;

namespace FootballBookmakerSystem.Client
{
    public class FootballApp
    {
        public static void Main(string[] args)
        {
            var context = new FootballContext();
            context.Database.Initialize(true);
        }
    }
}