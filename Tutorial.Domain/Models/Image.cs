using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
   public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string AltText { get; set; }
        public virtual int SessionId { get; set; }
        public virtual Session Session { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Image()
        {
            Session = new Session();
            Course = new Course();
        }

    }
}
