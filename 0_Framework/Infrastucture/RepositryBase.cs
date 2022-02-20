using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastucture
{
    public class RepositryBase<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(Tkey key)
        {
           return _context.Find<T>(key);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
