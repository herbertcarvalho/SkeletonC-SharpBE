using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Domain.Repositories
{
    public interface IProdutoRepository : IRepositoryAsync<Entities.Produto>
    {
        Task<Entities.Produto> GetQueryByIdAsync(Guid id);
    }
}