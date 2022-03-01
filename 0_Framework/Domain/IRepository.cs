using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public interface IRepository<Tkey , T> where T: class
    {
        T Get(Tkey key);
        List<T> GetAll();
        void Create(T entity);
        bool Exist(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
