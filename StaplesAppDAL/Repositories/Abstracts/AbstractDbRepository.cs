using StaplesAppDAL.Context;
using StaplesAppDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StaplesAppDAL.Repositories.Abstracts
{
    public abstract class AbstractDbRepository<T>: IRepository<T>
        where T : class, IBasicEntity
    {
        public async Task AddAsync(T entity)
        {
            using (var db = new StaplesDbContext())
            {
                db.Set<T>().Add(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetWhereAsync(params Expression<Func<T, bool>>[] whereExpression)
        {
            using (var db = new StaplesDbContext())
            {
                if (whereExpression.Any())
                {
                    IQueryable<T> dataSet = db.Set<T>();

                    foreach (var expression in whereExpression)
                    {
                        dataSet = dataSet.Where(expression);
                    }

                    return await dataSet.ToListAsync();
                }
                else
                {
                    return await db.Set<T>().ToListAsync();
                }

            }
        }
    }

}
