﻿using System;
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

        public IEnumerable<BllRole> GetAll(Expression<Func<BllRole, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllRole, DalRole>(Expression.Parameter(typeof(DalRole), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalRole, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetAll(expression).Select(r => r.ToBllEntity()).ToList();
        }

        public BllRole GetById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repository.GetById(id)?.ToBllEntity();
        }

        public BllRole GetByPredicate(Expression<Func<BllRole, bool>> predicate)
        {
            var visitor = new ParameterTypeVisitor<BllRole, DalRole>(Expression.Parameter(typeof(DalRole), predicate.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalRole, bool>>(visitor.Visit(predicate.Body), visitor.ParameterExpression);
            return repository.GetByPredicate(expression).ToBllEntity();
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
