using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
  public  class SubjectKeyword
    {
        #region Fields
        public int SubjectKeywordId { get; set; }

        public string SubjectKeywordValue { get; set; }
        #endregion

        #region Navigations
        public virtual int KeywordId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Keyword Keyword { get; set; }
        public virtual Subject Subject { get; set; }
        #endregion

        #region ctor
        public SubjectKeyword()
        {
            Keyword = new Keyword();
            Subject = new Subject();
        }
        #endregion

    }
}
