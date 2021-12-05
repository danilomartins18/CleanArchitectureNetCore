using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IBaseRepository<Product> _product;

        public IBaseRepository<Product> Product => _product ??= new BaseRepository<Product>(_context);

        IBaseRepository<Product> IUnitOfWork.Product => throw new System.NotImplementedException();

        public UnitOfWork(ApplicationContext context) => _context = context;

        public bool Commit() => _context.SaveChanges() > 0;

        public void Dispose() => _context.Dispose();
    }
}
