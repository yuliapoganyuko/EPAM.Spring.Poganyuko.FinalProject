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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext dbContext;

        public RoleRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(DalRole entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Role>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalRole entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                Role role = dbContext.Set<Role>().Find(entity.Id);
                dbContext.Set<Role>().Remove(role);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalRole> GetAll()
        {
            return dbContext.Set<Role>().Select(r => r.ToDalEntity()).ToList();
        }

        public IEnumerable<DalRole> GetAll(Expression<Func<DalRole, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<DalRole, Role>(Expression.Parameter(typeof(Role), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Role, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            var roles = dbContext.Set<Role>().Where(expression).ToList();
            return roles.Select(role => role.ToDalEntity());
        }

        public DalRole GetById(int id)
        {
            Role role = dbContext.Set<Role>().Find(id);
            return role?.ToDalEntity();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> predicate)
        {
            return GetAll(predicate).FirstOrDefault();
        }

        public void Update(DalRole entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Role>().AddOrUpdate<Role>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
