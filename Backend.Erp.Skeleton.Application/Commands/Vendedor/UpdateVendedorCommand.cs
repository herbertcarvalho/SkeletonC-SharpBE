using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Vendedor
{
    public record UpdateVendedorCommand(Guid Id, VendedorRequest VendedorRequest) : IRequest<Result<Guid>>;

    public class UpdateVendedorCommandHandler : IRequestHandler<UpdateVendedorCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IVendedorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVendedorCommandHandler(IVendedorRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateVendedorCommand request, CancellationToken cancellationToken)
        {
            var vendedor = await _repository.GetByIdAsync(request.Id);
            if (vendedor is null)
                throw new KeyNotFoundException($"{nameof(Vendedor)} Not Found.");

            _mapper.Map(request.VendedorRequest, vendedor);
            await _repository.UpdateAsync(vendedor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(vendedor.Id);
        }
    }
}