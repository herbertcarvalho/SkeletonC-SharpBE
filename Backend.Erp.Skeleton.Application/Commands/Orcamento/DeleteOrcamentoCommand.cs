using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Orcamento
{
    public record DeleteOrcamentoCommand(Guid Id) : IRequest<Result<Guid>>;

    public class DeleteOrcamentoCommandHandler : IRequestHandler<DeleteOrcamentoCommand, Result<Guid>>
    {
        private readonly IOrcamentoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrcamentoCommandHandler(
            IOrcamentoRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteOrcamentoCommand request, CancellationToken cancellationToken)
        {
            var orcamento = await _repository.GetByIdAsync(request.Id);
            if (orcamento is null)
                throw new KeyNotFoundException($"{nameof(Orcamento)} Not Found.");

            await _repository.DeleteAsync(orcamento);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(orcamento.Id);
        }
    }
}