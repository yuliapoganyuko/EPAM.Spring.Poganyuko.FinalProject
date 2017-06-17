using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface;
using DAL.Interface.Repositories;
using System.Linq;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PhotoService(IPhotoRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void AddNewLike(BllLike like)
        {
            if (ReferenceEquals(like, null))
                throw new ArgumentNullException();
            repository.AddNewLike(like.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Create(BllPhoto entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Create(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Delete(BllPhoto entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Delete(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public IEnumerable<BllPhoto> GetAll()
        {
            return repository.GetAll().Select(entity => entity.ToBllEntity()).ToList();
        }

        public BllPhoto GetById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetById(id)?.ToBllEntity();
        }

        public IEnumerable<BllLike> GetLikesForPhoto(int photoId)
        {
            if (photoId < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetLikesForPhoto(photoId).Select(l => l.ToBllEntity()).ToList();
        }

        public IEnumerable<BllTag> GetTagsForPhoto(int photoId)
        {
            if (photoId < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetTagsForPhoto(photoId).Select(t => t.ToBllEntity()).ToList();
        }

        public void RemoveLike(BllLike like)
        {
            if (ReferenceEquals(like, null))
                throw new ArgumentNullException();
            repository.RemoveLike(like.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Update(BllPhoto entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Update(entity.ToDalEntity());
            unitOfWork.Commit();
        }
    }
}
