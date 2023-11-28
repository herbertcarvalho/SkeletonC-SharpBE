using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Produto
{
    public record DeleteProdutoCommand(Guid Id) : IRequest<Result<Guid>>;

    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, Result<Guid>>
    {
        private readonly IProdutoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProdutoCommandHandler(
            IProdutoRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id);
            if (produto is null)
                throw new KeyNotFoundException($"{nameof(Produto)} Not Found.");

            await _repository.DeleteAsync(produto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(produto.Id);
        }
    }
}