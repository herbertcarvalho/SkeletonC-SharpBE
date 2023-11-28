using Backend.Erp.Skeleton.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Domain.Repositories
{
    public interface IClienteRepository : IRepositoryAsync<Cliente>
    {
        Task<Cliente> GetQueryByIdAsync(Guid id);
        Task<Cliente> GetQueryByDocAsync(string doc);
    }
}