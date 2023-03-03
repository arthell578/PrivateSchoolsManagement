namespace PrivateSchoolsManagement.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
