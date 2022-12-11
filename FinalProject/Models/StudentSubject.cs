namespace FinalProject.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public int Point { get; set; }
    }
}
