using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
   public class Course
    {
        #region Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartYear { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Slug { get; set; }
        public int ViewCount { get; set; }
        public int Size { get; set; }
        #endregion

        #region Navigations
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }


        #endregion

        #region ctor
        public Course()
        {
            Tutor = new Tutor();
            Images = new List<Image>();
            Sessions = new List<Session>();
            Comments = new List<Comment>();
            Enrollments = new List<Enrollment>();
            Subject = new Subject();
        }
        #endregion

    }
}
