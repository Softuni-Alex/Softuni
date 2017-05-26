using System.Collections.Generic;

namespace InheritanceAndPolymorphism.Interfaces
{
    public interface ICourse
    {
        string CourseName { get; }
        string TeacherName { get; }

        IList<string> Students { get; }
        void AddStudent(string studentName);
    }
}
