using Backend.Erp.Skeleton.Domain.Entities;
using Backend.Erp.Skeleton.Domain.Repositories;
using Backend.Erp.Skeleton.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryAsync<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cliente> GetQueryByIdAsync(Guid id)
        {
            var result = await Query()
               .Include(x => x.Endereco)
               .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Cliente> GetQueryByDocAsync(string doc)
        {
            var result = await Query()
               .Include(x => x.Endereco)
               .FirstOrDefaultAsync(x => x.Doc == doc);

            return result;
        }
    }
}