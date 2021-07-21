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
    public class StudentRepository : IStudentRepository
    {
        private readonly TutorialDbContext db;
        public StudentRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }
        public OperationResult AddNew(Student Current)
        {
            OperationResult op = new OperationResult("Ad dNew Student");
            try
            {
                this.db.Students.Add(Current);
                db.SaveChanges();
                return op.Succeed("Student Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Student Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete");
            try
            {
                var student = db.Students.FirstOrDefault(x => x.Id == ID);
                if (student == null)
                {
                    return op.Failed("This Course does not Exist");
                }

                if (student.Enrollments.Any())
                {
                    return op.Failed("student has related Enrollment");

                }


                db.Students.Remove(student);
                db.SaveChanges();
                return op.Succeed("student Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("student Remove Failed " + ex.Message);
            }
        }


        public Student Get(int ID)
        {
            return db.Students.FirstOrDefault(x => x.Id == ID);
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public OperationResult Update(Student Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update Student");
            try
            {

                this.db.Students.Attach(Current);
                db.Entry<Student>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Student  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Student Update Failed : " + ex.Message);

            }
        }
    }
}
