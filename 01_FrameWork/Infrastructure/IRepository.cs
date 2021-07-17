using _01_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _01_FrameWork.Infrastructure
{
    public interface IRepository<in TKey , T> where T : DomainBase<TKey>
    {
        List<T> GetAll();
        void Create(T entity);
        T Get(TKey id);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
