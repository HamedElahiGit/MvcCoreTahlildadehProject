using Framework.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Query.Session
{
   public class SessionSearchModel : PageModel
    {
        public string SessionName { get; set; }
        public string ShortDescription { get; set; }
    }
}
