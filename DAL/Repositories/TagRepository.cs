using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DAL.Interface;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;

namespace DAL.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DbContext dbContext;

        public TagRepository(DbContext context)
        {
            dbContext = context;
        }
        
        public void Create(DalTag entity)
        {
            
        }

        public void Delete(DalTag entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalTag GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTag entity)
        {
            throw new NotImplementedException();
        }
    }
}
