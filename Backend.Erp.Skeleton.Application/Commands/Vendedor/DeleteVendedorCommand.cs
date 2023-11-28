using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Vendedor
{
    public record DeleteVendedorCommand(Guid Id) : IRequest<Result<Guid>>;

    public class DeleteVendedorCommandHandler : IRequestHandler<DeleteVendedorCommand, Result<Guid>>
    {
        private readonly IVendedorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVendedorCommandHandler(
            IVendedorRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteVendedorCommand request, CancellationToken cancellationToken)
        {
            var vendedor = await _repository.GetByIdAsync(request.Id);
            if (vendedor is null)
                throw new KeyNotFoundException($"{nameof(Vendedor)} Not Found.");

            await _repository.DeleteAsync(vendedor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(vendedor.Id);
        }
    }
}