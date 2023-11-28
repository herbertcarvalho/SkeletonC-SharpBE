using Backend.Erp.Skeleton.Domain.Extensions;
using static Backend.Erp.Skeleton.Domain.Enums.TipoClienteEnum;
using static Backend.Erp.Skeleton.Domain.Enums.TipoStatusEnum;
using System;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Vendedor : Entity
    {
        public string FirebaseId { get; set; }
        public string Doc { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public Status Status { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; } 
        public string CanalVenda { get; set; } 
        public string GestorVenda { get; set; } 
        public string LojaVenda { get; set; } 
        public string GrupoVenda { get; set; } 
        public DateTime DataNascimento { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}