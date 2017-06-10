using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Repositories;

namespace Unikreativ.Repositories.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private GenericRepository<User> _userRepository;

        public UnitOfWork() : this(new ApplicationDbContext())
        {
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_dbContext);
                }
                return _userRepository;
            }
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext == null) return;
            _dbContext.Dispose();
            _dbContext = null;
        }
    }
}