namespace Json
{
    public class JsonApp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            context.Database.Initialize(true);
        }
    }
}