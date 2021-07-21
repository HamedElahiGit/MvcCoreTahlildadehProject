using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
   public class ProjectController
    {
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string PersianTitle { get; set; }
        public virtual int ProjectAreaId { get; set; }
        public virtual ProjectArea ProjectArea { get; set; }
        public virtual ICollection<ProjectAction> ProjectActions { get; set; }
        public ProjectController()
        {
            ProjectArea = new ProjectArea();
            ProjectActions = new List<ProjectAction>();
        }
    }
}
