using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using ServiceStack.OrmLite;

namespace BlogApplication.Database
{
    public class BaseRepository<T>
    {
        private IDbConnection db;
        public IDbConnection Db => db ?? (db = MvcApplication.DbFactory.OpenDbConnection());

        public virtual Task<T> GetByIdAsync(int id)
        {
            return Db.SingleByIdAsync<T>(id);
        }

        public virtual async Task<long> InsertAsync(T entity)
        {
            var id = await Db.InsertAsync(entity, selectIdentity: true);
            return id;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var tasks = new List<Task>();
            tasks.Add(Db.UpdateAsync(entity));

            await Task.WhenAll(tasks);
        }

        public virtual async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var tasks = new List<Task>();
            tasks.Add(Db.DeleteAsync(expression));
            await Task.WhenAll(tasks);
        }
    }
}