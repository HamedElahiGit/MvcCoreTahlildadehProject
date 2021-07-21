using Framework.Domain.BaseModels;
using Framework.Domain.Persistence;
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
    public class SessionKeywordRepository : ISessionKeywordRepository
    {
        private readonly TutorialDbContext db;
        public SessionKeywordRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }

        public OperationResult AddNew(SessionKeyword Current)
        {
            OperationResult op = new OperationResult("AddNew SessionKeyword");
            try
            {

                this.db.SessionKeywords.Add(Current);
                db.SaveChanges();
                return op.Succeed("SessionKeyword Added Successfully", Current.SessionKeywordId);
            }
            catch (Exception ex)
            {
                return op.Failed("SessionKeyword Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete SessionKeyword");
            try
            {
                var sk = db.SessionKeywords.FirstOrDefault(x => x.SessionKeywordId == ID);
                if (sk == null)
                {
                    return op.Failed("This SessionKeyword does not Exist");
                }



                db.SessionKeywords.Remove(sk);
                db.SaveChanges();
                return op.Succeed("SessionKeyword Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("SessionKeyword Remove Failed " + ex.Message);
            }
        }

        public SessionKeyword Get(int ID)
        {
            return db.SessionKeywords.FirstOrDefault(x => x.SessionKeywordId == ID);
        }

        public List<SessionKeyword> GetAll()
        {
            return db.SessionKeywords.ToList();
        }

        public OperationResult Update(SessionKeyword Current)
        {
            OperationResult op = new OperationResult(Current.SessionKeywordId, "Update SessionKeyword");
            try
            {

                this.db.SessionKeywords.Attach(Current);
                db.Entry<SessionKeyword>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update SessionKeyword  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("SessionKeyword Update Failed : " + ex.Message);

            }
        }
    }
}
