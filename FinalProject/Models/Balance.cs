namespace FinalProject.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Debt { get; set; }

        public Semester Semester { get; set; }
        public Student Student { get; set; }
    }
}
