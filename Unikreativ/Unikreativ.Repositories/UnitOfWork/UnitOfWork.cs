using System;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Repositories;

namespace Unikreativ.Repositories.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Project> _projectRepository;
        private GenericRepository<Event> _eventRepository;
        public UnitOfWork() : this(new ApplicationDbContext())
        {
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GenericRepository<User> UserRepository => _userRepository ?? (_userRepository = new GenericRepository<User>(_dbContext));

        public GenericRepository<Project> ProjectRepository => _projectRepository ?? (_projectRepository = new GenericRepository<Project>(_dbContext));

        public GenericRepository<Event> EventRepository => _eventRepository ?? (_eventRepository = new GenericRepository<Event>(_dbContext));
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