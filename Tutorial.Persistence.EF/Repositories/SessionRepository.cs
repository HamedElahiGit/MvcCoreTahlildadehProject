using Framework.Domain.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Query.Session;
using Tutorial.Domain.Services;
using Tutorial.Persistence.EF.Context;

namespace Tutorial.Persistence.EF.Repositories
{
  public  class SessionRepository : ISessionRepository
    {
        private readonly TutorialDbContext db;
        public SessionRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }
        public OperationResult AddNew(Session Current)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                this.db.Sessions.Add(Current);
                db.SaveChanges();
                return op.Succeed("Session Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Session Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete Session");
            try
            {
                var session = db.Sessions.FirstOrDefault(x => x.Id == ID);
                if (session == null)
                {
                    return op.Failed("This Session does not Exist");
                }


                db.Sessions.Remove(session);
                db.SaveChanges();
                return op.Succeed("Session Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("Session Remove Failed " + ex.Message);
            }
        }


        public Session Get(int ID)
        {
            return db.Sessions.FirstOrDefault(x => x.Id == ID);
        }

        public List<Session> GetAll()
        {
            return db.Sessions.ToList();
        }

        public List<SessionListItem> Search(SessionSearchModel sm, out int recordCount)
        {
            var q = db.Sessions.Select(x => new SessionListItem
            {
                Id = x.Id,
                SessionNo = x.SessionNo,
                SessionTitle = x.SessionTitle,
                ShortDescription = x.ShortDescription,
                Duration = x.Duration,
            });
            if (!string.IsNullOrEmpty(sm.SessionName))
            {
                q = q.Where(x => x.SessionTitle.Contains(sm.SessionName));
            }
            if (!string.IsNullOrEmpty(sm.ShortDescription))
            {
                q = q.Where(x => x.ShortDescription.Contains(sm.ShortDescription));
            }

            recordCount = q.Count();
            return q.OrderBy(x => x.SessionTitle).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(Session Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update Session");
            try
            {

                this.db.Sessions.Attach(Current);
                db.Entry<Session>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Session  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Session Update Failed : " + ex.Message);

            }
        }
    }
}
