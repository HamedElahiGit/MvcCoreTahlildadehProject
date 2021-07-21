using Framework.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Query.Subject;

namespace Tutorial.Domain.Services
{
   public interface ISubjectRepository : IBaseRepository<Subject, int>,IBaseRepositorySearchable<Subject,int,SubjectSearchModel, Query.Subject.SubjectListItem>
    {
    }
}
