using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
   public class ProjectArea
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string PersianTitle { get; set; }
        public virtual ICollection<ProjectController> ProjectControllers { get; set; }

        public ProjectArea()
        {
            ProjectControllers = new List<ProjectController>();
        }
    }
}
