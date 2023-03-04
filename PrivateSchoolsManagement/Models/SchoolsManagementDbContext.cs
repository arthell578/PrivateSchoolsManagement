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
            // Configure one-to-many relationship between Teacher and Class
            // modelBuilder.Entity<Teacher>()
            //     .HasMany(t => t.Classes)
            //     .WithOne(c => c.Teacher)
            //     .HasForeignKey(c => c.TeacherId)
            //     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Class)
                .HasForeignKey(s => s.ClassId);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Subject)
                .WithOne()
                .HasForeignKey<Class>(c => c.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure many-to-many relationship between Class and Student
            // modelBuilder.Entity<Class>()
            //     .HasMany(c => c.Students)
            //     .WithMany(s => s.Classes)
            //     .UsingEntity<Dictionary<string, object>>(
            //         "ClassStudent",
            //         j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
            //         j => j.HasOne<Class>().WithMany().HasForeignKey("ClassId"),
            //         j => j.HasKey("ClassId", "StudentId"));

            // Configure one-to-many relationship between Class and Grade
            modelBuilder.Entity<Class>()
                .HasMany(c => c.Grades)
                .WithOne(g => g.Class)
                .HasForeignKey(g => g.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure composite key for Grade entity
            modelBuilder.Entity<Grade>()
                .HasKey(g => new { g.ClassId, g.StudentId });
        }
    }
}
