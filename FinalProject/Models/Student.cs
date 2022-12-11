namespace FinalProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public int StartYear { get; set; }

        public Department Department { get; set; }
        public Address Address { get; set; }
        public Semester Semester { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
        public IEnumerable<Balance> Balances { get; set; }
    }
}
