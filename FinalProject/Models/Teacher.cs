namespace FinalProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }

        public Subject Subject { get; set; }
        public Department Department { get; set; }
        public Address Address { get; set; }

    }
}
