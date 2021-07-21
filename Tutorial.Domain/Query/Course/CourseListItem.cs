using Framework.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Query.Course
{
   public class CourseListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartYear { get; set; }
        public string ShortDescription { get; set; }
        public int Duration { get; set; }
        public int SessionCount { get; set; }

    }
}
