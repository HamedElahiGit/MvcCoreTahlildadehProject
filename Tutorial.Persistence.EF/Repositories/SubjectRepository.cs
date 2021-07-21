using Framework.Domain.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Query.Subject;
using Tutorial.Domain.Services;
using Tutorial.Persistence.EF.Context;

namespace Tutorial.Persistence.EF.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly TutorialDbContext db;
        public SubjectRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }
        public OperationResult AddNew(Subject Current)
        {
            OperationResult op = new OperationResult("AddNew Subject");
            try
            {
                this.db.Subjects.Add(Current);
                db.SaveChanges();
                return op.Succeed("Subject Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Subject Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete Subject");
            try
            {
                var subject = db.Subjects.FirstOrDefault(x => x.Id == ID);
                if (subject == null)
                {
                    return op.Failed("This Subject does not Exist");
                }


                db.Subjects.Remove(subject);
                db.SaveChanges();
                return op.Succeed("Subject Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("Subject Remove Failed " + ex.Message);
            }
        }


        public Subject Get(int ID)
        {
            return db.Subjects.FirstOrDefault(x => x.Id == ID);
        }

        public List<Subject> GetAll()
        {
            return db.Subjects.ToList();
        }

        public List<SubjectListItem> Search(SubjectSearchModel sm, out int recordCount)
        {
            var q = db.Subjects.Select(x => new SubjectListItem
            {
                Id = x.Id,
                SubjectValue = x.SubjectValue,
                SmallDescription = x.SmallDescription,
            });
            if (!string.IsNullOrEmpty(sm.SubjectName))
            {
                q = q.Where(x => x.SubjectValue.Contains(sm.SubjectName));
            }
            if (!string.IsNullOrEmpty(sm.Keyword))
            {
                q = q.Where(x => x.SmallDescription.Contains(sm.Keyword));
            }

            recordCount = q.Count();
            return q.OrderBy(x => x.SubjectValue).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(Subject Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update Subject");
            try
            {

                this.db.Subjects.Attach(Current);
                db.Entry<Subject>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Subject  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Subject Update Failed : " + ex.Message);

            }
        }
    }
}
