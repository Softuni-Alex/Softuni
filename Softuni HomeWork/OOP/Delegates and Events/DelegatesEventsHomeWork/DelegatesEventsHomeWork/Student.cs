namespace DelegatesEventsHomeWork
{
    class Student
    {

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name { get; set; }
        public int Grade { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Grade: {1}", this.Name, this.Grade);
        }
    }
}
