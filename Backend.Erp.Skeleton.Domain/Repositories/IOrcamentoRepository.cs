using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Domain.Repositories
{
    public interface IOrcamentoRepository : IRepositoryAsync<Entities.Orcamento>
    {
        Task<Entities.Orcamento> GetQueryByIdAsync(Guid id);
    }
}