﻿using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
