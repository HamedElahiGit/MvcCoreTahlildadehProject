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
    public class SubjectKeywordRepository : ISubjectKeywordRepository
    {
        private readonly TutorialDbContext db;
        public SubjectKeywordRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }

        public OperationResult AddNew(SubjectKeyword Current)
        {
            OperationResult op = new OperationResult("AddNew SubjectKeyword");
            try
            {

                this.db.SubjectKeywords.Add(Current);
                db.SaveChanges();
                return op.Succeed("SubjectKeyword Added Successfully", Current.SubjectKeywordId);
            }
            catch (Exception ex)
            {
                return op.Failed("SubjectKeyword Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete SubjectKeyword");
            try
            {
                var sk = db.SubjectKeywords.FirstOrDefault(x => x.SubjectKeywordId == ID);
                if (sk == null)
                {
                    return op.Failed("This SubjectKeyword does not Exist");
                }



                db.SubjectKeywords.Remove(sk);
                db.SaveChanges();
                return op.Succeed("SubjectKeyword Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("SubjectKeyword Remove Failed " + ex.Message);
            }
        }

        public SubjectKeyword Get(int ID)
        {
            return db.SubjectKeywords.FirstOrDefault(x => x.SubjectKeywordId == ID);
        }

        public List<SubjectKeyword> GetAll()
        {
            return db.SubjectKeywords.ToList();
        }

        public OperationResult Update(SubjectKeyword Current)
        {
            OperationResult op = new OperationResult(Current.SubjectKeywordId, "Update SubjectKeyword");
            try
            {

                this.db.SubjectKeywords.Attach(Current);
                db.Entry<SubjectKeyword>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update SubjectKeyword  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("SubjectKeyword Update Failed : " + ex.Message);

            }
        }
    }
}
