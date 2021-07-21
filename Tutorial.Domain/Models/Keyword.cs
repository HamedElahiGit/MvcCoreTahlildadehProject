using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
   public class Keyword
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SubjectKeyword> SubjectKeywords { get; set; }
        public virtual ICollection<SessionKeyword> SessionKeywords { get; set; }
        public Keyword()
        {
            SubjectKeywords = new List<SubjectKeyword>();
            SessionKeywords = new List<SessionKeyword>();
        }


    }
}
