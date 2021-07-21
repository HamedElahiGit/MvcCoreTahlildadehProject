using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
   public class Session
    {
        #region Fields
        public int Id { get; set; }
        public string SessionTitle { get; set; }
        public int SessionNo { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Size { get; set; }
        public DateTime SessionDateTime { get; set; }
        #endregion

        #region Navigations
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<SessionKeyword> SessionKeywords { get; set; }

        #endregion

        #region ctor
        public Session()
        {
            Course = new Course();
            Images = new List<Image>();
            Files = new List<File>();
            SessionKeywords = new List<SessionKeyword>();
        }
        #endregion

    }
}
