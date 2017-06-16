using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IService<TEntity> where TEntity: IBllEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
