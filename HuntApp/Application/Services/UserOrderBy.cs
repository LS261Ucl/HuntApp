using System;
using System.Linq;
using UserApi.Application.Interfaces;
using UserApi.Entities;

namespace UserApi.Application.Services
{
    public class UserOrderBy : IOrderBy<User>
    {
        public Func<IQueryable<User>, IOrderedQueryable<User>> Sorting(string orderBy)
        {
            switch (orderBy)
            {
                case "nameDesc":
                    return x => x.OrderByDescending(p => p.Name);
                default:
                    return x => x.OrderBy(p => p.Name);
            }
        }
    }
}
