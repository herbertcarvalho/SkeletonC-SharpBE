using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Orcamento
{
    public record UpdateOrcamentoCommand(Guid Id, OrcamentoRequest OrcamentoRequest) : IRequest<Result<Guid>>;

    public class UpdateOrcamentoCommandHandler : IRequestHandler<UpdateOrcamentoCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IOrcamentoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrcamentoCommandHandler(IOrcamentoRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateOrcamentoCommand request, CancellationToken cancellationToken)
        {
            var orcamento = await _repository.GetByIdAsync(request.Id);
            if (orcamento is null)
                throw new KeyNotFoundException($"{nameof(Orcamento)} Not Found.");

            _mapper.Map(request.OrcamentoRequest, orcamento);
            await _repository.UpdateAsync(orcamento);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(orcamento.Id);
        }
    }
}