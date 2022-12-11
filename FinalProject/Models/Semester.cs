namespace FinalProject.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableGPA { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<Balance> Balances { get; set; }
    }
}
