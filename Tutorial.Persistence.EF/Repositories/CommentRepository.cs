using Framework.Domain.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Services;
using Tutorial.Persistence.EF.Context;

namespace Tutorial.Persistence.EF.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TutorialDbContext db;
        public CommentRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }
        public OperationResult AddNew(Comment Current)
        {
            OperationResult op = new OperationResult("Add New Comment");
            try
            {
                if (Current==null)
                {
                    return op.Failed("this comment is null");
                }
                db.Comments.Add(Current);
                db.SaveChanges();
                return op.Succeed("this comment add successfully", Current.Id);

            }
            catch (Exception ex)
            {
                return op.Failed("Adding new comment failed" + ex.Message);
            }
        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete");
            try
            {
                var comment = db.Comments.FirstOrDefault(x => x.Id == ID);
                if (comment == null)
                {
                    return op.Failed("This Record does not Exist");
                }

                db.Comments.Remove(comment);
                db.SaveChanges();
                return op.Succeed("comment Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("comment Remove Failed " + ex.Message);
            }
        }

        public Comment Get(int ID)
        {
            return db.Comments.FirstOrDefault(x => x.Id == ID);
        }

        public List<Comment> GetAll()
        {
            return db.Comments.ToList();
        }

        public OperationResult Update(Comment Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update comment");
            try
            {

                this.db.Comments.Attach(Current);
                db.Entry<Comment>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Comment  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Comment Update Failed : " + ex.Message);

            }
        }
    }
}
