namespace FinalProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumbOfStudents { get; set; }
        public int CurrentAmount { get; set; }

        public Semester Semester { get; set; } //No idea why this is here
    }
}
