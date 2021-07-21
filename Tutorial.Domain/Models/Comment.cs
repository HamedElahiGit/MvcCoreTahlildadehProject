using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Models
{
  public  class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public bool CanPublish { get; set; }



        //Navigation
        public virtual int? ReplyToCommentId { get; set; }
        public virtual Comment ReplyToComment { get; set; }
        public virtual ICollection<Comment> TheCommentsThatRepliedToThisComment { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public Comment()
        {
            ReplyToComment = new Comment();
            TheCommentsThatRepliedToThisComment = new List<Comment>();
            Course = new Course();
        }

    }
}
