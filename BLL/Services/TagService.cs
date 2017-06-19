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
    public class TagService : ITagService
    {
        private readonly ITagRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public TagService(ITagRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(BllTag entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Create(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public void Delete(BllTag entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Delete(entity.ToDalEntity());
            unitOfWork.Commit();
        }

        public IEnumerable<BllTag> GetAll()
        {
            return repository.GetAll().Select(entity => entity.ToBllEntity()).ToList();
        }

        public IEnumerable<BllTag> GetAll(Expression<Func<BllTag, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllTag, DalTag>(Expression.Parameter(typeof(DalTag), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalTag, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetAll(expression).Select(t => t.ToBllEntity()).ToList();
        }

        public BllTag GetById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetById(id)?.ToBllEntity();
        }

        public BllTag GetByPredicate(Expression<Func<BllTag, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllTag, DalTag>(Expression.Parameter(typeof(DalTag), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalTag, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetByPredicate(expression).ToBllEntity();
        }

        public void Update(BllTag entity)
        {
            if (ReferenceEquals(entity, null))
                throw new ArgumentNullException();
            repository.Update(entity.ToDalEntity());
            unitOfWork.Commit();
        }
    }
}
