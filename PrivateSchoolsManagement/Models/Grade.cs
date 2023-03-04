using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrivateSchoolsManagement.Models
{
    public class Grade
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }

        [MaxLength(100)]
        public string Note { get; set; }

        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
