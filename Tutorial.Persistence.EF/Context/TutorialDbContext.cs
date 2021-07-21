using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Persistence.EF.Configurations;

namespace Tutorial.Persistence.EF.Context
{
   public class TutorialDbContext:DbContext
    {
        public TutorialDbContext(DbContextOptions<TutorialDbContext> options):base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionKeyword> SessionKeywords { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectKeyword> SubjectKeywords { get; set; }
        public DbSet<Tutor> Tutors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Comment>(new CommentConfig());
            modelBuilder.ApplyConfiguration<Course>(new CourseConfig());
            modelBuilder.ApplyConfiguration<Enrollment>(new EnrollmentConfig());
            modelBuilder.ApplyConfiguration<File>(new FileConfig());
            modelBuilder.ApplyConfiguration<Image>(new ImageConfig());
            modelBuilder.ApplyConfiguration<Keyword>(new KeywordConfig());
            modelBuilder.ApplyConfiguration<Session>(new SessionConfig());
            modelBuilder.ApplyConfiguration<SessionKeyword>(new SessionKeywordConfig());
            modelBuilder.ApplyConfiguration<Student>(new StudentConfig());
            modelBuilder.ApplyConfiguration<Subject>(new SubjectConfig());
            modelBuilder.ApplyConfiguration<SubjectKeyword>(new SubjectKeywordConfig());
            modelBuilder.ApplyConfiguration<Tutor>(new TutorConfig());
        }
    }
}
