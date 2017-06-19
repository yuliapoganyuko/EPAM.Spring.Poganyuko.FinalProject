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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext dbContext;

        public UserRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(DalUser entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<User>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalUser entity)
        {
            User user = dbContext.Set<User>().Find(entity.Id);
            if (!ReferenceEquals(user, null))
            {
                Profile profile = dbContext.Set<Profile>().Find(user.Id);
                if (!ReferenceEquals(profile, null))
                {
                    var photos = dbContext.Set<Photo>().Where(p => p.UserId == profile.UserId);
                    if (!ReferenceEquals(photos, null))
                        foreach (var photo in photos)
                            dbContext.Set<Photo>().Remove(photo);
                    dbContext.Set<Profile>().Remove(profile);
                    dbContext.Set<User>().Remove(user);
                    dbContext.SaveChanges();
                }
            }
        }

        public IEnumerable<DalUser> GetAll()
        {
            return dbContext.Set<User>().Select(u => u.ToDalEntity()).ToList();
        }

        public IEnumerable<DalUser> GetAll(Expression<Func<DalUser, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<DalUser, User>(Expression.Parameter(typeof(User), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<User, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            var users = dbContext.Set<User>().Where(expression).ToList();
            return users.Select(user => user.ToDalEntity());
        }

        public DalUser GetById(int id)
        {
            User user = dbContext.Set<User>().Find(id);
            return user?.ToDalEntity();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {
            return GetAll(predicate).FirstOrDefault();
        }

        public void Update(DalUser entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<User>().AddOrUpdate<User>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
