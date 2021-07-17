using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using _01_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_FrameWork.Infrastructure
{
    public class BaseRepository<TKey , T> : IRepository<TKey , T> where T : DomainBase<TKey>
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            this._context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public T Get(TKey id)
        {
           return _context.Find<T>(id);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }
    }
}
