using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchoolsManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }

        public ICollection<Class> Classes { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
