using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NEA.Areas.Identity.Data;

namespace NEA.Models
{
    public class NEAContext : IdentityDbContext<NEAUser>
    {
        public NEAContext(DbContextOptions<NEAContext> options)
            : base(options)
        {
        }
        public DbSet<ClassAssignment> ClassAssignments { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Simulation> Simulations { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<StudentQuestion> StudentQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ClassAssignment>().ToTable("ClassAssignment");
            builder.Entity<Classroom>().ToTable("Classroom");
            builder.Entity<Enrollment>().ToTable("Enrollment");
            builder.Entity<Simulation>().ToTable("Simulation");
            builder.Entity<StudentAssignment>().ToTable("StudentAssignment");
            builder.Entity<StudentQuestion>().ToTable("StudentQuestion");
            builder.Entity<Question>().ToTable("Question");
            builder.Entity<QuestionType>().ToTable("QuestionType");

            builder.Entity<Enrollment>()
                .HasKey(e => new { e.NEAUserId, e.ClassroomID });
            builder.Entity<ClassAssignment>()
                .HasKey(c => new { c.ClassroomID, c.SimulationID });
            builder.Entity<StudentAssignment>()
                .HasKey(s => new { s.UserID, s.SimulationID });
            builder.Entity<Question>()
                .HasKey(q => new { q.SimulationID, q.QIndex });
            builder.Entity<StudentQuestion>()
                .HasKey(s => new { s.SimulationID, s.QIndex, s.UserID });

            builder.Entity<Question>()
                .HasMany(q => q.StudentQuestions)
                .WithOne(s => s.Question)
                .HasForeignKey(s => new { s.SimulationID, s.QIndex });

            builder.Entity<Enrollment>()
                .HasOne(e => e.NEAUser)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentQuestion>()
                .HasOne(e => e.Question)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
