using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Application.Commands.Produto
{
    public record InsertProdutoCommand(Guid EmpresaId,ProdutoRequest ProdutoRequest) : IRequest<Result<Guid>>;

    public class InsertProdutoCommandHandler : IRequestHandler<InsertProdutoCommand, Result<Guid>>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertProdutoCommandHandler(IProdutoRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(InsertProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _mapper.Map<Domain.Entities.Produto>(request.ProdutoRequest);

            await _repository.AddAsync(produto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(produto.Id);
        }
    }
}