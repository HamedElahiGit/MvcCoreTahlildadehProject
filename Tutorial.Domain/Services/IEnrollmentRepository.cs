using Framework.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;

namespace Tutorial.Domain.Services
{
   public interface IEnrollmentRepository:IBaseRepository<Enrollment,int>
    {
    }
}
