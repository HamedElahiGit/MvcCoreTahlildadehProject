using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
  public  class Enrollment
    {
        public int EnrollmentId { get; set; }
        public virtual int CourseId { get; set; }
        public virtual int StudentId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Enrollment()
        {
            Course = new Course();
            Student = new Student();
        }

    }
}
