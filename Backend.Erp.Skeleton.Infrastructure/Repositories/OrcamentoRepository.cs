using Backend.Erp.Skeleton.Domain.Entities;
using Backend.Erp.Skeleton.Domain.Repositories;
using Backend.Erp.Skeleton.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Infrastructure.Repositories
{
    public class OrcamentoRepository : RepositoryAsync<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Orcamento> GetQueryByIdAsync(Guid id)
        {
            var result = await Query()
               .Include(x => x.Imovel)
               .Include(x => x.Aparelho)
               .Include(x => x.Interruptores)
               .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}