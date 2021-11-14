using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Application.Interfaces
{
    public interface IOrderBy<T> where T : class
    {
        Func<IQueryable<T>, IOrderedQueryable<T>> Sorting(string orderBy);
    }
}
