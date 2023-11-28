using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Cliente
{
    public record UpdateClienteCommand(Guid Id, ClienteRequest ClienteRequest) : IRequest<Result<Guid>>;

    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClienteCommandHandler(IClienteRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);
            if (cliente is null)
                throw new KeyNotFoundException($"{nameof(Cliente)} Not Found.");

            _mapper.Map(request.ClienteRequest, cliente);
            await _repository.UpdateAsync(cliente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(cliente.Id);
        }
    }
}