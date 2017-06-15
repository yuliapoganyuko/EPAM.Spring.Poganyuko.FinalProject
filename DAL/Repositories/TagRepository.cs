using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;

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
            if (entity != null)
            {
                dbContext.Set<Tag>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalTag entity)
        {
            if (entity != null)
            {
                Tag tag = dbContext.Set<Tag>().Single(t => t.Id == entity.Id);
                dbContext.Set<Tag>().Remove(tag);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalTag> GetAll()
        {
            return dbContext.Set<Tag>().Select(t => t.ToDalEntity()).ToList();
        }

        public DalTag GetById(int id)
        {
            Tag tag = dbContext.Set<Tag>().FirstOrDefault(t => t.Id == id);
            return tag?.ToDalEntity();
        }

        public void Update(DalTag entity)
        {
            if (entity != null)
            {
                dbContext.Set<Tag>().AddOrUpdate<Tag>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }
    }
}
