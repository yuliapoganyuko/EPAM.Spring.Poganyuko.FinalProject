using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface;
using DAL.Interface.Repositories;
using System.Linq;

namespace BLL.Services
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IRoleRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(BllRole entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Create(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Delete(BllRole entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Delete(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public IEnumerable<BllRole> GetAll()
        {
            return repository.GetAll().Select(entity => entity.ToBllEntity()).ToList();
        }

        public BllRole GetById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetById(id)?.ToBllEntity();
        }

        public void Update(BllRole entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Update(entity.ToDalEntity());
            unitOfWork.Commit();
        }
    }
}
