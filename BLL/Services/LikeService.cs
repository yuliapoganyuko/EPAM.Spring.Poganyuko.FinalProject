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
    public class LikeService: ILikeService
    {
        private readonly ILikeRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public LikeService(ILikeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(BllLike entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Create(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Delete(BllLike entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Delete(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public IEnumerable<BllLike> GetAll()
        {
            return repository.GetAll().Select(entity => entity.ToBllEntity()).ToList();
        }

        public IEnumerable<BllLike> GetAll(Expression<Func<BllLike, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllLike, DalLike>(Expression.Parameter(typeof(DalLike), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalLike, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetAll(expression).Select(like => like.ToBllEntity()).ToList();
        }

        public BllLike GetById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetById(id)?.ToBllEntity();
        }

        public BllLike GetByPredicate(Expression<Func<BllLike, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllLike, DalLike>(Expression.Parameter(typeof(DalLike), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalLike, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetByPredicate(expression).ToBllEntity();
        }

        public void Update(BllLike entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Update(entity.ToDalEntity());
            unitOfWork.Commit();
        }
    }
}
