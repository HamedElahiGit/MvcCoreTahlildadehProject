using Framework.Domain.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Query.Course;
using Tutorial.Domain.Services;
using Tutorial.Persistence.EF.Context;

namespace Tutorial.Persistence.EF.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TutorialDbContext db;
        public CourseRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }
        public OperationResult AddNew(Course Current)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                if (this.ExistCourseName(Current.Name))
                {
                    return op.Failed("this Course Name Already Exist");
                }

                this.db.Courses.Add(Current);
                db.SaveChanges();
                return op.Succeed("Course Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Course Add Failed : " + ex.Message);
            }

        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete");
            try
            {
                var course = db.Courses.FirstOrDefault(x => x.Id == ID);
                if (course == null)
                {
                    return op.Failed("This Course does not Exist");
                }

                if (course.Sessions.Any())
                {
                    return op.Failed("Course has related Session");

                }
                if (course.Enrollments.Any())
                {
                    return op.Failed("Course has related Enrollment");

                }


                db.Courses.Remove(course);
                db.SaveChanges();
                return op.Succeed("Course Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("Course Remove Failed " + ex.Message);
            }
        }

        public bool ExistCourseName(string courseName)
        {
            return this.db.Courses.Any(x => x.Name == courseName);
        }

        public bool ExistCourseNameForAnyOtherSupplier(string courseName, int courseId)
        {
            return this.db.Courses.Any(x => x.Name == courseName && x.Id!= courseId);
        }

        public Course Get(int ID)
        {
            return db.Courses.FirstOrDefault(x => x.Id == ID);
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public List<CourseListItem> Search(CourseSearchModel sm, out int recordCount)
        {
            var q = db.Courses.Select(x => new CourseListItem
            {
                Id = x.Id,
                Name = x.Name,
                SessionCount = x.Sessions.Count,
                ShortDescription = x.ShortDescription,
                Duration=x.Duration,
                StartYear=x.StartYear
            });
            if (!string.IsNullOrEmpty(sm.CourseName))
            {
                q = q.Where(x => x.Name.Contains(sm.CourseName));
            }
            if (!string.IsNullOrEmpty(sm.ShortDescription))
            {
                q = q.Where(x => x.ShortDescription.Contains(sm.ShortDescription));
            }

            recordCount = q.Count();
            return q.OrderBy(x => x.Name).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(Course Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update Course");
            try
            {

                this.db.Courses.Attach(Current);
                db.Entry<Course>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Course  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Course Update Failed : " + ex.Message);

            }
        }
    }
}
