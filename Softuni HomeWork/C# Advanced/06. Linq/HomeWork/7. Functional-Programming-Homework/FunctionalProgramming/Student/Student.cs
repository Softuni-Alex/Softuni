namespace Student
{
    using System.Collections.Generic;

    public class Student
    {
        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, int groupNumber, IList<int> marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.Marks = marks;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int GroupNumber { get; set; }
        public IList<int> Marks { get; set; }
    }
}