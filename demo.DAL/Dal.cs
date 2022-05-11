using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAL
{
    public class Dal<T> : IDal<T> where T : class, new()
    {
        private readonly MyContext db;

        public Dal(MyContext db)
        {
            this.db = db;
        }

        public int Add(T entity)
        {
              db.Add(entity);
                return db.SaveChanges();
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().Where(where);
        }
    }
}
