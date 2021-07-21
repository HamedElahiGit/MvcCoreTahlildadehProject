using Framework.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Query.Course
{
   public class CourseSearchModel:PageModel
    {
        public string CourseName { get; set; }
        public string ShortDescription { get; set; }
    }
}
