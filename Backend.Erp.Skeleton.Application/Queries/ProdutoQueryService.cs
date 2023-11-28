using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Application.Interfaces.Queries;
using Backend.Erp.Skeleton.Domain.Entities;
using Backend.Erp.Skeleton.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Contas.Application.Queries
{
    internal class ProdutoQueryService : IProdutoQueryService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _repository;

        public ProdutoQueryService(
            IMapper mapper,
            IProdutoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaginatedResult<ProdutoResponse>> GetAllAsync(PageOption pageOption, Guid empresaId)
        {
            var list = _repository.Query();
            var listProduto = await list
                .Select(x => new ProdutoResponse
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    ValorUnitario = x.ValorUnitario,
                    Tipo = x.Tipo,
                    Quantidade = x.Quantidade,
                    Descricao = x.Descricao,
                    DataCriacao = x.CreatedAt,
                    DataModificacao = x.UpdatedAt
                }).OrderBy(x => x.DataCriacao)
                .ToPaginatedListAsync(pageOption.Page, pageOption.PageSize);

            return listProduto;
        }

        public async Task<Result<ProdutoResponse>> GetByIdAsync(Guid clienteId)
        {
            var produto = await _repository.GetQueryByIdAsync(clienteId);
            if (produto is null)
                throw new KeyNotFoundException($"{nameof(Produto)} Not Found.");

            var result = new ProdutoResponse
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Nome = produto.Nome,
                Quantidade = produto.Quantidade,
                Tipo = produto.Tipo,
                ValorUnitario = produto.ValorUnitario,
                DataCriacao = produto.CreatedAt,
                DataModificacao = produto.UpdatedAt,
            };
            return Result<ProdutoResponse>.Success(result);
        }
    }
}