using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
   public class File
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public virtual int SessionId { get; set; }
        public virtual Session Session { get; set; }

    }
}
