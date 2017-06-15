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
    public class PhotoRepository : IPhotoRepository
    {

        private readonly DbContext dbContext;

        public PhotoRepository(DbContext context)
        {
            dbContext = context;
        }

        public void AddNewLike(DalLike like)
        {
            throw new NotImplementedException();
        }

        public void AddNewTag(DalTag tag)
        {
            throw new NotImplementedException();
        }

        public void Create(DalPhoto entity)
        {
            if (entity != null)
            {
                dbContext.Set<Photo>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalPhoto entity)
        {
            if (entity != null)
            {
                Photo photo = dbContext.Set<Photo>().Single(p => p.Id == entity.Id);
                dbContext.Set<Photo>().Remove(photo);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return dbContext.Set<Photo>().Select(p => p.ToDalEntity()).ToList();
        }

        public DalPhoto GetById(int id)
        {
            Photo photo = dbContext.Set<Photo>().FirstOrDefault(p => p.Id == id);
            return photo?.ToDalEntity();
        }

        public void Update(DalPhoto entity)
        {
            if (entity != null)
            {
                dbContext.Set<Photo>().AddOrUpdate<Photo>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalLike> GetLikesForPhoto(int photoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> GetTagsForPhoto(int photoId)
        {
            throw new NotImplementedException();
        }

        public void RemoveLike(DalLike like)
        {
            throw new NotImplementedException();
        }
    }
}
