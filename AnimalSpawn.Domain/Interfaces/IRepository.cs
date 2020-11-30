using AnimalSpawn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task Add(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        Task Delete(int id);
        void Update(T entity);
    }
}
