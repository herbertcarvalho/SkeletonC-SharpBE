using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Cliente
{
    public record DeleteClienteCommand(Guid Id) : IRequest<Result<Guid>>;

    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Result<Guid>>
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClienteCommandHandler(
            IClienteRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);
            if (cliente is null)
                throw new KeyNotFoundException($"{nameof(Cliente)} Not Found.");

            await _repository.DeleteAsync(cliente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(cliente.Id);
        }
    }
}