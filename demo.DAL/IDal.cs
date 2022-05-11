using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAL
{
    using System.Linq.Expressions;

    public  interface IDal<T> where T : class,new()
    {
       int Add(T entity);
       IQueryable<T> Select( Expression<Func<T,bool>> where);
    }
}
