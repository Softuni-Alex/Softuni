using System;

namespace InheritanceAndPolymorphism
{
    internal class CoursesExamples
    {
        private static void Main()
        {
            LocalCourse localCourse = new LocalCourse("DataBase", "Alex Den", "OpenSource");
            Console.WriteLine(localCourse);

            localCourse.AddStudent("Alex");
            localCourse.AddStudent("Pel");
            Console.WriteLine(localCourse);

            localCourse.AddStudent("Amg");
            localCourse.AddStudent("Lek");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(".net programming", "George Men", "Sofia");
            offsiteCourse.AddStudent("Den");
            offsiteCourse.AddStudent("Jo");
            offsiteCourse.AddStudent("Omer");
            Console.WriteLine(offsiteCourse);
        }
    }
}