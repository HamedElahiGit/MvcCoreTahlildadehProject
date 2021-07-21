using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
   public class SessionKeyword
    {
        #region Fields
        public int SessionKeywordId { get; set; }

        public string SessionKeywordValue { get; set; }
        #endregion

        #region Navigations
        public virtual int KeywordId { get; set; }
        public virtual int SessionId { get; set; }
        public virtual Keyword Keyword { get; set; }
        public virtual Session Session { get; set; }
        #endregion

        #region ctor
        public SessionKeyword()
        {
            Keyword = new Keyword();
            Session = new Session();
        }
        #endregion

    }
}
