namespace PrivateSchoolsManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
