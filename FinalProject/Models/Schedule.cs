namespace FinalProject.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Room? Room { get; set; }
        public Semester Semester { get; set; }
        public Subject Subject { get; set; }
    }
}
