using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyControl.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<bool> AddAsync(TEntity obj);
        Task<bool> AddRangeAsync(IEnumerable<TEntity> obj);
        Task<bool> UpdateAsync(Guid id, TEntity obj);
        Task<bool> RemoveAsync(Guid id);
        
       


        
    }
}
