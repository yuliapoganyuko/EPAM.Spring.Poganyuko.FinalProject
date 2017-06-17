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
            Photo photo = dbContext.Set<Photo>().First(p => p.Id == like.PhotoId);
            dbContext.Set<Photo>().Attach(photo);
            photo.Likes.Add(like.ToOrmEntity());
            dbContext.SaveChanges();
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
            Photo photo = dbContext.Set<Photo>().First(p => p.Id == photoId);
            return photo.Likes.ToList().Select(l => l.ToDalEntity());
        }

        public IEnumerable<DalTag> GetTagsForPhoto(int photoId)
        {
            Photo photo = dbContext.Set<Photo>().First(p => p.Id == photoId);
            return photo.Tags.ToList().Select(p => p.ToDalEntity());
        }

        public void RemoveLike(DalLike like)
        {
            Photo photo = dbContext.Set<Photo>().First(p => p.Id == like.PhotoId);
            photo.Likes.Remove(like.ToOrmEntity());
            Like ormLike = dbContext.Set<Like>().First(l => l.UserId == like.UserId && l.PhotoId == like.PhotoId);
            dbContext.Set<Like>().Remove(ormLike);
            dbContext.SaveChanges();
        }
    }
}
