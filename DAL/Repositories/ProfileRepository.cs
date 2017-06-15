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
    public class ProfileRepository : IProfileRepository
    {
        private readonly DbContext dbContext;

        public ProfileRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(DalProfile entity)
        {
            if (entity != null)
            {
                dbContext.Set<Profile>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalProfile entity)
        {
            if (entity != null)
            {
                Profile profile = dbContext.Set<Profile>().Single(p => p.UserId == entity.Id);
                dbContext.Set<Profile>().Remove(profile);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalProfile> GetAll()
        {
            return dbContext.Set<Profile>().Select(p => p.ToDalEntity()).ToList();
        }

        public DalProfile GetById(int id)
        {
            Profile profile = dbContext.Set<Profile>().FirstOrDefault(p => p.UserId == id);
            return profile?.ToDalEntity();
        }

        public void Update(DalProfile entity)
        {
            if (entity != null)
            {
                dbContext.Set<Profile>().AddOrUpdate<Profile>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
