using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System.Linq.Expressions;
using System;
using DAL.Interface;

namespace DAL.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DbContext dbContext;

        public TagRepository(DbContext context)
        {
            dbContext = context;
        }
        
        public void Create(DalTag entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Tag>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalTag entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                Tag tag = dbContext.Set<Tag>().Find(entity.Id);
                dbContext.Set<Tag>().Remove(tag);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalTag> GetAll()
        {
            return dbContext.Set<Tag>().Select(t => t.ToDalEntity()).ToList();
        }

        public IEnumerable<DalTag> GetAll(Expression<Func<DalTag, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<DalTag, Tag>(Expression.Parameter(typeof(Tag), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Tag, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            var tags = dbContext.Set<Tag>().Where(expression).ToList();
            return tags.Select(tag => tag.ToDalEntity());
        }

        public DalTag GetById(int id)
        {
            Tag tag = dbContext.Set<Tag>().Find(id);
            return tag?.ToDalEntity();
        }

        public DalTag GetByPredicate(Expression<Func<DalTag, bool>> predicate)
        {
            return GetAll(predicate).FirstOrDefault();
        }

        public void Update(DalTag entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Tag>().AddOrUpdate<Tag>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
