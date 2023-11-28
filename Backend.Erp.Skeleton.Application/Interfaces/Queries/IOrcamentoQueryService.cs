using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Interfaces.Queries
{
    public interface IOrcamentoQueryService
    {
        Task<PaginatedResult<OrcamentoResponse>> GetAllAsync(PageOption pageOption);
        Task<Result<OrcamentoResponse>> GetByIdAsync(Guid id);
    }
}