using Framework.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Query.Session;

namespace Tutorial.Domain.Services
{
  public  interface ISessionRepository : IBaseRepository<Session, int>,IBaseRepositorySearchable<Session,int,SessionSearchModel,SessionListItem>
    {
    }
}
