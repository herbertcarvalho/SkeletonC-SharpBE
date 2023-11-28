using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Domain.Repositories
{
    public interface IVendedorRepository : IRepositoryAsync<Entities.Vendedor>
    {
        Task<Entities.Vendedor> GetQueryByIdAsync(Guid id);
    }
}