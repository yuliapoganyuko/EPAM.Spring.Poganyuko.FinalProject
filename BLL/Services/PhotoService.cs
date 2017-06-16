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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<BllTag> GetTagsForPhoto(int photoId)
        {
            throw new NotImplementedException();
        }

        public void RemoveLike(BllLike like)
        {
            throw new NotImplementedException();
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
