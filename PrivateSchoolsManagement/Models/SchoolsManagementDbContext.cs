using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrivateSchoolsManagement.Models
{
    public class SchoolsManagementDbContext : DbContext
    {
        public SchoolsManagementDbContext(DbContextOptions<SchoolsManagementDbContext> options)
           : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
