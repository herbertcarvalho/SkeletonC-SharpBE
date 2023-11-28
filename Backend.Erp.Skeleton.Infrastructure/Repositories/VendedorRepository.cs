using Backend.Erp.Skeleton.Domain.Entities;
using Backend.Erp.Skeleton.Domain.Repositories;
using Backend.Erp.Skeleton.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Infrastructure.Repositories
{
    public class VendedorRepository : RepositoryAsync<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Vendedor> GetQueryByIdAsync(Guid id)
        {
            var result = await Query()
               .Include(x => x.Endereco)
               .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}