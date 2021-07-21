using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Persistence
{
  public  interface IBaseRepositorySearchable<TModel,TKey,TSearchModel,TListItem>
  {
      List<TListItem> Search(TSearchModel sm, out int recordCount);
  }
}
