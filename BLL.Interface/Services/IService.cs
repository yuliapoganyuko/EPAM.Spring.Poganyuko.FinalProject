using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IService<TEntity> where TEntity: IBllEntity
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity GetById(int id);

        TEntity GetByPredicate(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
