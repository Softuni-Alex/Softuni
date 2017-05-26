using System.Linq;

namespace Softuni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniEntities context = new SoftUniEntities();

            using (context)
            {
                //                Town townOne = new Town();
                //                townOne.Name = "Studentski Grad";
                //
                //                context.Towns.Add(townOne);
                //                context.SaveChanges();

                Town st = context.Towns.FirstOrDefault(town => town.Name == "Sofia");
                context.Addresses.RemoveRange(st.Addresses);
                context.Towns.Remove(st);
                context.SaveChanges();
            }
        }
    }
}