using System;
using Unikreativ.Repositories.Interface;

namespace Unikreativ.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;

        void Commit();

        void Rollback();
    }
}