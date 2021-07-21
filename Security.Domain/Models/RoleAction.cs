using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
  public  class RoleAction
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int ProjectActionId { get; set; }
        public virtual ProjectAction ProjectAction { get; set; }
        public bool HasPermission { get; set; }
        public RoleAction()
        {
            Role = new Role();
            ProjectAction = new ProjectAction();
        }
    }
}
