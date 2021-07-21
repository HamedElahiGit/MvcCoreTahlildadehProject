using Framework.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Query.Subject
{
   public class SubjectSearchModel : PageModel
    {
        public string SubjectName { get; set; }
        public string Keyword { get; set; }
    }
}
