using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface;
using DAL.Interface.Repositories;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;

namespace BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(BllUser entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Create(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Delete(BllUser entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Delete(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public IEnumerable<BllUser> GetAll()
        {
            return repository.GetAll().Select(entity => entity.ToBllEntity()).ToList();
        }

        public IEnumerable<BllUser> GetAll(Expression<Func<BllUser, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllUser, DalUser>(Expression.Parameter(typeof(DalUser), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalUser, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetAll(expression).Select(u => u.ToBllEntity()).ToList();
        }

        public BllUser GetById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetById(id)?.ToBllEntity();
        }

        public BllUser GetByPredicate(Expression<Func<BllUser, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllUser, DalUser>(Expression.Parameter(typeof(DalUser), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalUser, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetByPredicate(expression).ToBllEntity();
        }

        public void Update(BllUser entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Update(entity.ToDalEntity());
            unitOfWork.Commit();
        }
    }
}
