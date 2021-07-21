using Framework.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Query.Session
{
   public class SessionListItem
    {
        public int Id { get; set; }
        public string SessionTitle { get; set; }
        public int SessionNo { get; set; }
        public string ShortDescription { get; set; }
        public int Duration { get; set; }

    }
}
