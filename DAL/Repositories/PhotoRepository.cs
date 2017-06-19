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
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DbContext dbContext;

        public PhotoRepository(DbContext context)
        {
            dbContext = context;
        }

        public void AddNewLike(DalLike like)
        {
            Photo photo = dbContext.Set<Photo>().Find(like.PhotoId);
            dbContext.Set<Photo>().Attach(photo);
            photo.Likes.Add(like.ToOrmEntity());
            dbContext.SaveChanges();
        }
        
        public void Create(DalPhoto entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Photo>().Add(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public void Delete(DalPhoto entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                Photo photo = dbContext.Set<Photo>().Find(entity.Id);
                dbContext.Set<Photo>().Remove(photo);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return dbContext.Set<Photo>().Select(p => p.ToDalEntity()).ToList();
        }

        public IEnumerable<DalPhoto> GetAll(Expression<Func<DalPhoto, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<DalPhoto, Photo>(Expression.Parameter(typeof(Photo), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Photo, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            var photos = dbContext.Set<Photo>().Where(expression).ToList();
            return photos.Select(p => p.ToDalEntity());
        }

        public DalPhoto GetById(int id)
        {
            Photo photo = dbContext.Set<Photo>().Find(id);
            return photo?.ToDalEntity();
        }

        public DalPhoto GetByPredicate(Expression<Func<DalPhoto, bool>> predicate)
        {
            return GetAll(predicate).FirstOrDefault();
        }

        public void Update(DalPhoto entity)
        {
            if (!ReferenceEquals(entity, null))
            {
                dbContext.Set<Photo>().AddOrUpdate<Photo>(entity.ToOrmEntity());
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<DalLike> GetLikesForPhoto(int photoId)
        {
            Photo photo = dbContext.Set<Photo>().Find(photoId);
            return photo.Likes.ToList().Select(l => l.ToDalEntity());
        }

        public IEnumerable<DalTag> GetTagsForPhoto(int photoId)
        {
            Photo photo = dbContext.Set<Photo>().Find(photoId);
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
