using System;

namespace demo.BLL
{
    using System.Linq;
    using System.Linq.Expressions;
    public interface IBLL<T> where T : class,new()
    {
        int Add(T entity);
        IQueryable<T> Select(Expression<Func<T,bool> > where);
    }
}
