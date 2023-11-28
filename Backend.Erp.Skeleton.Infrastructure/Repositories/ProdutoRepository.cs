using Backend.Erp.Skeleton.Domain.Entities;
using Backend.Erp.Skeleton.Domain.Repositories;
using Backend.Erp.Skeleton.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Infrastructure.Repositories
{
    public class ProdutoRepository : RepositoryAsync<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Produto> GetQueryByIdAsync(Guid id)
        {
            var result = await Query()
               .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}