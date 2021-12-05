using Domain.Bases;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly ApplicationContext _context;
		private readonly DbSet<T> _dataset;

		public BaseRepository(ApplicationContext context)
		{
			_context = context;
			_dataset = _context.Set<T>();
		}
		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

				if (result == null)
					return false;

				_dataset.Remove(result);
				//await _context.SaveChangesAsync();
				return true;
			}
            catch (Exception)
            {
                throw;
            }
		}

		public async Task<T> InsertAsync(T item)
		{
			try
			{
				//if (item.Id == Guid.Empty)
				//{
				//	item.Id = Guid.NewGuid();
				//}

				await _dataset.AddAsync(item);

				//await _context.SaveChangesAsync();
			}
			catch (Exception)
            {
                throw;
            }
			return item;
		}

		public async Task<T> SelectAsync(Guid id)
		{
			try
			{
				return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
			}
            catch (Exception)
            {

                throw;
            }
		}

		public async Task<IEnumerable<T>> SelectAsync()
		{
            try
            {
				return await _dataset.ToListAsync();
			}
			catch (Exception)
            {
                throw;
            }
		}

		public async Task<T> UpdateAsync(T item)
		{
			try
			{
				var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

				if (result == null)
					return null;

				_context.Entry(result).CurrentValues.SetValues(item);

				//await _context.SaveChangesAsync();
			}
            catch (Exception)
            {
                throw;
            }
			return item;
		}
	}
}
