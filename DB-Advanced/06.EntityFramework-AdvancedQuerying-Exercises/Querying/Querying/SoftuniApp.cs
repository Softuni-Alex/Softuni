using System;

namespace Querying
{
    public class SoftuniApp
    {
        public static void Main()
        {
            var context = new SoftUniEntities1();
            var projects = context.FindAllProjects("Ruth", "Ellerbrock");

            foreach (var findAllProjectsResult in projects)
            {
                Console.WriteLine($"{findAllProjectsResult.Name} {findAllProjectsResult.Description}");
            }
        }
    }
}