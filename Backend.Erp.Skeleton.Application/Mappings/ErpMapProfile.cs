using AutoMapper;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Domain.Entities;

namespace Backend.Contas.Application.Mappings
{
    public class ErpMapProfile : Profile
    {
        public ErpMapProfile()
        {
            //Request
            CreateMap<ClienteRequest, Cliente>().ReverseMap();
            CreateMap<EnderecoRequest, Endereco>().ReverseMap();
            CreateMap<ProdutoRequest, Produto>().ReverseMap();
            CreateMap<VendedorRequest, Vendedor>().ReverseMap();
       
            //Response
            CreateMap<ClienteResponse, Cliente>()
                .ForPath(x => x.CreatedAt, y => y.MapFrom(k => k.DataCriacao))
                .ForPath(x => x.UpdatedAt, y => y.MapFrom(k => k.DataModificacao))
                .ReverseMap();

            CreateMap<EnderecoResponse, Endereco>()
                .ForPath(x => x.CreatedAt, y => y.MapFrom(k => k.DataCriacao))
                .ForPath(x => x.UpdatedAt, y => y.MapFrom(k => k.DataModificacao))
                .ReverseMap();

            CreateMap<ProdutoResponse, Produto>()
                .ForPath(x => x.CreatedAt, y => y.MapFrom(k => k.DataCriacao))
                .ForPath(x => x.UpdatedAt, y => y.MapFrom(k => k.DataModificacao))
                .ReverseMap();

            CreateMap<VendedorResponse, Vendedor>()
                .ForPath(x => x.CreatedAt, y => y.MapFrom(k => k.DataCriacao))
                .ForPath(x => x.UpdatedAt, y => y.MapFrom(k => k.DataModificacao))
                .ReverseMap();

            CreateMap(typeof(PaginatedResult<>), typeof(PaginatedResult<>));
            CreateMap(typeof(Result<>), typeof(Result<>));
        }
    }
}