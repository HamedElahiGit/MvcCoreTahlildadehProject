using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
  public  class Subject
    {
        public int Id { get; set; }
        public string SubjectValue { get; set; }
        public string SmallDescription { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Subject()
        {
            Courses = new List<Course>();

        }

    }
}
