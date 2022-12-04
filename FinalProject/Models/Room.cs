namespace FinalProject.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public int MaxNumberOfStudents { get; set; }
    }
}
