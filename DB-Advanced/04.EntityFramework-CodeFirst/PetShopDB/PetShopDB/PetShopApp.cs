namespace PetShopDB
{
    public class PetShopApp
    {
        static void Main()
        {
            PetShopContext context = new PetShopContext();

            context.SaveChanges();
        }
    }
}