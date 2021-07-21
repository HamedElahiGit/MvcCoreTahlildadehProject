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

    public class KeywordRepository : IKeywordRepository
    {
        private readonly TutorialDbContext db;
        public KeywordRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }

        public OperationResult AddNew(Keyword Current)
        {
            OperationResult op = new OperationResult("AddNew Keyword");
            try
            {

                this.db.Keywords.Add(Current);
                db.SaveChanges();
                return op.Succeed("Keyword Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Keyword Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete Keyword");
            try
            {
                var keyword = db.Keywords.FirstOrDefault(x => x.Id == ID);
                if (keyword == null)
                {
                    return op.Failed("This Keyword does not Exist");
                }



                db.Keywords.Remove(keyword);
                db.SaveChanges();
                return op.Succeed("Keyword Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("Keyword Remove Failed " + ex.Message);
            }
        }

        public Keyword Get(int ID)
        {
            return db.Keywords.FirstOrDefault(x => x.Id == ID);
        }

        public List<Keyword> GetAll()
        {
            return db.Keywords.ToList();
        }

        public OperationResult Update(Keyword Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update Keyword");
            try
            {

                this.db.Keywords.Attach(Current);
                db.Entry<Keyword>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Keyword  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Keyword Update Failed : " + ex.Message);

            }
        }
    }
}
