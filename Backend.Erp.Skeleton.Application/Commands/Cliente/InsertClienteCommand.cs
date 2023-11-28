using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Cliente
{
    public record InsertClienteCommand(IFormFile File,ClienteRequest ClienteRequest) : IRequest<Result<Guid>>;

    public class InsertClienteCommandHandler : IRequestHandler<InsertClienteCommand, Result<Guid>>
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertClienteCommandHandler(IClienteRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(InsertClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Domain.Entities.Cliente>(request.ClienteRequest);

            await _repository.AddAsync(cliente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(cliente.Id);
        }
    }
}