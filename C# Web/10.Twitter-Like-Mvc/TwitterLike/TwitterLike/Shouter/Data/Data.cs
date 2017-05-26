namespace Shouter.Data
{
    public class Data
    {
        private static ShouterContext context;

        public static ShouterContext Context => context ?? (context = new ShouterContext());
    }
}
