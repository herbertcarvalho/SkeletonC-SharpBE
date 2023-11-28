using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Orcamento
{
    public record InsertOrcamentoCommand(OrcamentoRequest OrcamentoRequest) : IRequest<Result<Guid>>;

    public class InsertOrcamentoCommandHandler : IRequestHandler<InsertOrcamentoCommand, Result<Guid>>
    {
        private readonly IOrcamentoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertOrcamentoCommandHandler(IOrcamentoRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(InsertOrcamentoCommand request, CancellationToken cancellationToken)
        {
            var orcamento = _mapper.Map<Domain.Entities.Orcamento>(request.OrcamentoRequest);

            await _repository.AddAsync(orcamento);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(orcamento.Id);
        }
    }
}