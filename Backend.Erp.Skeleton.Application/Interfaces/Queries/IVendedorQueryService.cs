using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Interfaces.Queries
{
    public interface IVendedorQueryService
    {
        Task<PaginatedResult<VendedorResponse>> GetAllAsync(PageOption pageOption, Guid empresaId);
        Task<Result<VendedorResponse>> GetByIdAsync(Guid id);
    }
}