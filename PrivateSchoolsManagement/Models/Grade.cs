namespace PrivateSchoolsManagement.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Note { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
