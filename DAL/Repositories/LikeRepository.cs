using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System;

namespace DAL.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DbContext dbContext;

        public LikeRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(DalLike entity)
        {
            if (entity != null)
            {
                dbContext.Set<Like>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalLike entity)
        {
            if (entity != null)
            {
                Like like = dbContext.Set<Like>().Single(l => l.Id == entity.Id);
                dbContext.Set<Like>().Remove(like);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalLike> GetAll()
        {
            return dbContext.Set<Like>().Select(l => l.ToDalEntity()).ToList();
        }

        public DalLike GetById(int id)
        {
            Like like = dbContext.Set<Like>().FirstOrDefault(l => l.Id == id);
            return like?.ToDalEntity();
        }

        public void Update(DalLike entity)
        {
            if (entity != null)
            {
                dbContext.Set<Like>().AddOrUpdate<Like>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
