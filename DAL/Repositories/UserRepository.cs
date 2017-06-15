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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext dbContext;

        public UserRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(DalUser entity)
        {
            if (entity != null)
            {
                dbContext.Set<User>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalUser entity)
        {
            if (entity != null)
            {
                User user = dbContext.Set<User>().Single(u => u.Id == entity.Id);
                dbContext.Set<User>().Remove(user);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalUser> GetAll()
        {
            return dbContext.Set<User>().Select(u => u.ToDalEntity()).ToList();
        }

        public DalUser GetById(int id)
        {
            User user = dbContext.Set<User>().FirstOrDefault(u => u.Id == id);
            return user?.ToDalEntity();
        }

        public void Update(DalUser entity)
        {
            if (entity != null)
            {
                dbContext.Set<User>().AddOrUpdate<User>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
