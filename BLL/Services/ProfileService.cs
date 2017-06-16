using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface;
using DAL.Interface.Repositories;
using System.Linq;

namespace BLL.Services
{
    public class ProfileService: IProfileService
    {
        private readonly IProfileRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ProfileService(IProfileRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(BllProfile entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Create(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Delete(BllProfile entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Delete(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public IEnumerable<BllProfile> GetAll()
        {
            return repository.GetAll().Select(entity => entity.ToBllEntity()).ToList();
        }

        public BllProfile GetById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetById(id)?.ToBllEntity();
        }

        public void Update(BllProfile entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Update(entity.ToDalEntity());
            unitOfWork.Commit();
        }
    }
}
