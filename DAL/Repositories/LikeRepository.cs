using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System;
using System.Linq.Expressions;
using DAL.Interface;

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
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Like>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalLike entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                Like like = dbContext.Set<Like>().Find(entity.Id);
                dbContext.Set<Like>().Remove(like);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalLike> GetAll()
        {
            return dbContext.Set<Like>().Select(l => l.ToDalEntity()).ToList();
        }

        public IEnumerable<DalLike> GetAll(Expression<Func<DalLike, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<DalLike, Like>(Expression.Parameter(typeof(Like), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Like, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            var likes = dbContext.Set<Like>().Where(expression).ToList();
            return likes.Select(like => like.ToDalEntity());
        }

        public DalLike GetById(int id)
        {
            Like like = dbContext.Set<Like>().Find(id);
            return like?.ToDalEntity();
        }

        public DalLike GetByPredicate(Expression<Func<DalLike, bool>> predicate)
        {
            return GetAll(predicate).FirstOrDefault();
        }

        public void Update(DalLike entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Like>().AddOrUpdate<Like>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
