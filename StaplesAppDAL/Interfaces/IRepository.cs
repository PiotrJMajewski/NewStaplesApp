using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StaplesAppDAL.Interfaces
{
    interface IRepository<T> where T:class, IBasicEntity
    {
        Task AddAsync(T entity);
        Task<List<T>> GetWhereAsync(params Expression<Func<T, bool>>[] whereExpression);
    }
}
