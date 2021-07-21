using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain.BaseModels;

namespace Framework.Domain.Persistence
{
  public  interface IBaseRepository<TModel,TKey>
  {
      OperationResult Delete(TKey ID);
      OperationResult AddNew(TModel Current);
      OperationResult Update(TModel Current);
      TModel Get(TKey ID);
      List<TModel> GetAll();
  }
}
