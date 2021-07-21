using Framework.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Query.Course;

namespace Tutorial.Domain.Services
{
  public  interface ICourseRepository : IBaseRepository<Course, int>,IBaseRepositorySearchable<Course,int,CourseSearchModel,CourseListItem>
    {
        bool ExistCourseName(string courseName);
        bool ExistCourseNameForAnyOtherSupplier(string courseName, int SuplierID);

    }
}
