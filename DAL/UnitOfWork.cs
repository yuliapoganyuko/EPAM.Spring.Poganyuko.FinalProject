using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context != null)
            {
                try
                {
                    Context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    throw new Exception("An error occured while commiting changes to database"); //particular exception?
                }
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
