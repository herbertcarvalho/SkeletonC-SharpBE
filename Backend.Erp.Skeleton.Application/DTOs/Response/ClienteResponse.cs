
using static Backend.Erp.Skeleton.Domain.Enums.TipoClienteEnum;
using static Backend.Erp.Skeleton.Domain.Enums.TipoStatusEnum;
using System;

namespace Backend.Erp.Skeleton.Application.DTOs.Response
{
    public class ClienteResponse : ExtensionData
    {
        public string Doc { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public Status Status { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}