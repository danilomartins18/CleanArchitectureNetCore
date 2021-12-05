using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories
        IBaseRepository<Product> Product { get; }
        //IBaseRepository<Provider> Provider { get; }
        #endregion

        bool Commit();
    }
}
