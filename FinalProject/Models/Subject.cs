namespace FinalProject.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public int Credit { get; set; }
        public string Name { get; set; }
        public int LowerBound { get; set; }

        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }

    }
}
