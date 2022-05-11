using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.BLL
{
    using demo.DAL;
    public class Bll<T> : IBLL<T> where T : class, new()
    {
        private readonly IDal<T> dal;

        public Bll(IDal<T> dal) {
            this.dal = dal;
        }

        public int Add(T entity)
        {
           return  dal.Add(entity);
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> where)
        {
            return dal.Select(where);
        }
    }
 
}
