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
    internal class VendedorQueryService : IVendedorQueryService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;

        public VendedorQueryService(
            IMapper mapper,
            IClienteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaginatedResult<VendedorResponse>> GetAllAsync(PageOption pageOption, Guid empresaId)
        {
            var list = _repository.Query()
                .Include(x => x.Endereco);
            var listVendedor = await list
                .Select(x => new VendedorResponse
                {
                    Id = x.Id,
                    Doc = x.Doc,
                    Email = x.Email,
                    Genero = x.Genero,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    Status = x.Status,
                    Telefone = x.Telefone,
                    TipoCliente = x.TipoCliente,
                    DataCriacao = x.CreatedAt,
                    DataModificacao = x.UpdatedAt,
                    Endereco = x.Endereco != null ? new EnderecoResponse 
                    {
                        Id = x.Endereco.Id,
                        Bairro = x.Endereco.Bairro,
                        Cep = x.Endereco.Cep,
                        Cidade = x.Endereco.Cidade,
                        Complemento = x.Endereco.Complemento,
                        Numero = x.Endereco.Numero,
                        Rua = x.Endereco.Rua,
                        Uf = x.Endereco.Uf,
                        DataCriacao = x.Endereco.CreatedAt,
                        DataModificacao = x.Endereco.UpdatedAt
                    } : null
                }).OrderBy(x => x.DataCriacao)
                .ToPaginatedListAsync(pageOption.Page, pageOption.PageSize);

            return listVendedor;
        }

        public async Task<Result<VendedorResponse>> GetByIdAsync(Guid clienteId)
        {
            var cliente = await _repository.GetQueryByIdAsync(clienteId);
            if (cliente is null)
                throw new KeyNotFoundException($"{nameof(Cliente)} Not Found.");

            var result = new VendedorResponse
            {
                Id = cliente.Id,
                Doc = cliente.Doc,
                Email = cliente.Email,
                Genero = cliente.Genero,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                Status = cliente.Status,
                Telefone = cliente.Telefone,
                TipoCliente = cliente.TipoCliente,
                DataCriacao = cliente.CreatedAt,
                DataModificacao = cliente.UpdatedAt,
                Endereco = cliente.Endereco != null ? new EnderecoResponse
                {
                    Id = cliente.Endereco.Id,
                    Bairro = cliente.Endereco.Bairro,
                    Cep = cliente.Endereco.Cep,
                    Cidade = cliente.Endereco.Cidade,
                    Complemento = cliente.Endereco.Complemento,
                    Numero = cliente.Endereco.Numero,
                    Rua = cliente.Endereco.Rua,
                    Uf = cliente.Endereco.Uf,
                    DataCriacao = cliente.Endereco.CreatedAt,
                    DataModificacao = cliente.Endereco.UpdatedAt
                } : null
            };
            return Result<VendedorResponse>.Success(result);
        }
    }
}