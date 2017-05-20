﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;

namespace Unikreativ.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public DbSet<User> _dbSet;
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
            _dbSet = context.Set<User>();
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Filter(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.UserName == name);
        }
    }
}