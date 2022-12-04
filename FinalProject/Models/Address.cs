namespace FinalProject.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
