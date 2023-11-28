using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Vendedor
{
    public record InsertVendedorCommand(VendedorRequest VendedorRequest) : IRequest<Result<Guid>>;

    public class InsertVendedorCommandHandler : IRequestHandler<InsertVendedorCommand, Result<Guid>>
    {
        private readonly IVendedorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertVendedorCommandHandler(IVendedorRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(InsertVendedorCommand request, CancellationToken cancellationToken)
        {
            var contas = _mapper.Map<Domain.Entities.Vendedor>(request.VendedorRequest);

            await _repository.AddAsync(contas);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(contas.Id);
        }
    }
}