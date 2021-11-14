using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Application.Services
{
    public class SessionsOrderBy : IOrderBy<Session>
    {
        public Func<IQueryable<Session>, IOrderedQueryable<Session>> Sorting(string orderBy)
        {
            switch (orderBy)
            {
                case "dateDesc":
                    return x => x.OrderByDescending(p => p.Date);
                default:
                    return x => x.OrderBy(p => p.Date);
            }
        }
    }
}
