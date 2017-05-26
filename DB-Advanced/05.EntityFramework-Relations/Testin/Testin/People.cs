namespace Testin
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Town BornTown { get; set; }

        public Town LivingTown { get; set; }
    }
}