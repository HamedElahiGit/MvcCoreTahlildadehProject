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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly TutorialDbContext db;
        public EnrollmentRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }

        public OperationResult AddNew(Enrollment Current)
        {
            OperationResult op = new OperationResult("Add New Enrollment");
            try
            {

                this.db.Enrollments.Add(Current);
                db.SaveChanges();
                return op.Succeed("Enrollment Added Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Enrollment Add Failed : " + ex.Message);
            }
        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete");
            try
            {
                var enrollment = db.Enrollments.FirstOrDefault(x => x.EnrollmentId == ID);
                if (enrollment == null)
                {
                    return op.Failed("This Enrollment does not Exist");
                }


                db.Enrollments.Remove(enrollment);
                db.SaveChanges();
                return op.Succeed("Enrollment Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("Enrollment Remove Failed " + ex.Message);
            }
        }

        public Enrollment Get(int ID)
        {
            return db.Enrollments.FirstOrDefault(x => x.EnrollmentId == ID);
        }

        public List<Enrollment> GetAll()
        {
            return db.Enrollments.ToList();
        }

        public OperationResult Update(Enrollment Current)
        {
            OperationResult op = new OperationResult(Current.EnrollmentId, "Update Enrollment");
            try
            {

                this.db.Enrollments.Attach(Current);
                db.Entry<Enrollment>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Enrollment Course  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Enrollment Update Failed : " + ex.Message);

            }
        }
    }
}
