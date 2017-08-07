using System;
using System.Collections.Generic;
using System.Linq;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
using Unikreativ.Repositories.Repositories;

namespace Unikreativ.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }


        public void Commit()
        {
            _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        ///// <summary>
        ///// Disposes the current object
        ///// </summary>
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        ///// <summary>
        ///// Disposes all external resources.
        ///// </summary>
        ///// <param name="disposing">The dispose indicator.</param>
        //private void Dispose(bool disposing)
        //{
        //    if (!disposing) return;
        //    if (_dbContext == null) return;
        //    _dbContext.Dispose();
        //    _dbContext = null;
        //}

    }
}