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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext dbContext;

        public RoleRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(DalRole entity)
        {
            if (entity != null)
            {
                dbContext.Set<Role>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalRole entity)
        {
            if (entity != null)
            {
                Role role = dbContext.Set<Role>().Single(r => r.Id == entity.Id);
                dbContext.Set<Role>().Remove(role);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalRole> GetAll()
        {
            return dbContext.Set<Role>().Select(r => r.ToDalEntity()).ToList();
        }

        public DalRole GetById(int id)
        {
            Role role = dbContext.Set<Role>().FirstOrDefault(r => r.Id == id);
            return role?.ToDalEntity();
        }

        public void Update(DalRole entity)
        {
            if (entity != null)
            {
                dbContext.Set<Role>().AddOrUpdate<Role>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
