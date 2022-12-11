namespace FinalProject.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public int Credit { get; set; }
        public string Name { get; set; }
        public int LowerBound { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
    }
}
