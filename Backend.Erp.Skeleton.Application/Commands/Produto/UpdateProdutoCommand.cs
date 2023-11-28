using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Produto
{
    public record UpdateProdutoCommand(Guid Id, ProdutoRequest ProdutoRequest) : IRequest<Result<Guid>>;

    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProdutoCommandHandler(IProdutoRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id);
            if (produto is null)
                throw new KeyNotFoundException($"{nameof(Produto)} Not Found.");

            _mapper.Map(request.ProdutoRequest, produto);
            await _repository.UpdateAsync(produto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(produto.Id);
        }
    }
}