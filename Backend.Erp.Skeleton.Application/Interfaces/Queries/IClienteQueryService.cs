using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Interfaces.Queries
{
    public interface IClienteQueryService
    {
        Task<PaginatedResult<ClienteResponse>> GetAllAsync(PageOption pageOption);
        Task<Result<ClienteResponse>> GetByIdAsync(Guid id);
        Task<Result<ClienteResponse>> GetByDocAsync(string doc);
    }
}