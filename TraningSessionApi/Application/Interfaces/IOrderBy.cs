using System;
using System.Linq;


namespace TraningSessionApi.Application.Interfaces
{
    public interface IOrderBy<T> where T : class
    {
        Func<IQueryable<T>, IOrderedQueryable<T>> Sorting(string orderBy);
    }
}
