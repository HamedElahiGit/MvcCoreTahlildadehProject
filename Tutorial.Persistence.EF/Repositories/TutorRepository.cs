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
    public class TutorRepository : ITutorRepository
    {
        private readonly TutorialDbContext db;
        public TutorRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }
        public OperationResult AddNew(Tutor Current)
        {
            OperationResult op = new OperationResult("Add New Tutor");
            try
            {

                this.db.Tutors.Add(Current);
                db.SaveChanges();
                return op.Succeed("Tutor Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Tutor Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete");
            try
            {
                var tutor = db.Tutors.FirstOrDefault(x => x.Id == ID);
                if (tutor == null)
                {
                    return op.Failed("This Tutor does not Exist");
                }

                if (tutor.Courses.Any())
                {
                    return op.Failed("Tutor has related Courses");

                }


                db.Tutors.Remove(tutor);
                db.SaveChanges();
                return op.Succeed("Course Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("Course Remove Failed " + ex.Message);
            }
        }

        public Tutor Get(int ID)
        {
            return db.Tutors.FirstOrDefault(x => x.Id == ID);
        }

        public List<Tutor> GetAll()
        {
            return db.Tutors.ToList();
        }

        public OperationResult Update(Tutor Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update Tutor");
            try
            {

                this.db.Tutors.Attach(Current);
                db.Entry<Tutor>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Tutor  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Tutor Update Failed : " + ex.Message);

            }
        }
    }
}
