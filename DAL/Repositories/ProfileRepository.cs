using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System;
using DAL.Interface;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DbContext dbContext;

        public ProfileRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(DalProfile entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Profile>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalProfile entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                Profile profile = dbContext.Set<Profile>().Find(entity.Id);
                dbContext.Set<Profile>().Remove(profile);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalProfile> GetAll()
        {
            return dbContext.Set<Profile>().Select(p => p.ToDalEntity()).ToList();
        }

        public IEnumerable<DalProfile> GetAll(Expression<Func<DalProfile, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<DalProfile, Profile>(Expression.Parameter(typeof(Profile), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Profile, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            var profiles = dbContext.Set<Profile>().Where(expression).ToList();
            return profiles.Select(profile => profile.ToDalEntity());
        }

        public DalProfile GetById(int id)
        {
            Profile profile = dbContext.Set<Profile>().Find(id);
            return profile?.ToDalEntity();
        }

        public DalProfile GetByPredicate(Expression<Func<DalProfile, bool>> predicate)
        {
            return GetAll(predicate).FirstOrDefault();
        }

        public void Update(DalProfile entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Profile>().AddOrUpdate<Profile>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
