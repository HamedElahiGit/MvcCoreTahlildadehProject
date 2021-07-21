using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
  public  class ProjectAction
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string PersianTitle { get; set; }
        public virtual int ProjectControllerId { get; set; }
        public virtual ProjectController ProjectController { get; set; }
        public virtual ICollection<RoleAction> RoleActions { get; set; }
        public ProjectAction()
        {
            ProjectController = new ProjectController();
            RoleActions = new List<RoleAction>();
        }
    }
}
