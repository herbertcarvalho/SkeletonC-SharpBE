using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Application.Interfaces.Queries;
using Backend.Erp.Skeleton.Domain.Entities;
using Backend.Erp.Skeleton.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Contas.Application.Queries
{
    internal class OrcamentoQueryService : IOrcamentoQueryService
    {
        private readonly IMapper _mapper;
        private readonly IOrcamentoRepository _repository;

        public OrcamentoQueryService(
            IMapper mapper,
            IOrcamentoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaginatedResult<OrcamentoResponse>> GetAllAsync(PageOption pageOption)
        {
            var list = _repository.Query();
            var listOrcamento = await list
                .Select(x => new OrcamentoResponse
                {
                    Id = x.Id,
                    DataCriacao = x.CreatedAt,
                    DataModificacao = x.UpdatedAt,
                }).OrderBy(x => x.DataCriacao)
                .ToPaginatedListAsync(pageOption.Page, pageOption.PageSize);

            return listOrcamento;
        }

        public async Task<Result<OrcamentoResponse>> GetByIdAsync(Guid clienteId)
        {
            var orcamento = await _repository.GetQueryByIdAsync(clienteId);
            if (orcamento is null)
                throw new KeyNotFoundException($"{nameof(OrdemServico)} Not Found.");

            var result = new OrcamentoResponse
            {
                Id = orcamento.Id,
                DataCriacao = orcamento.CreatedAt,
                DataModificacao = orcamento.UpdatedAt
            };
            return Result<OrcamentoResponse>.Success(result);
        }
    }
}