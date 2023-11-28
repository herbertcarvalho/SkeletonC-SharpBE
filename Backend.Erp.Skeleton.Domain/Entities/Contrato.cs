using Backend.Erp.Skeleton.Domain.Extensions;
using System;
using static Backend.Erp.Skeleton.Domain.Enums.TipoClienteEnum;
using static Backend.Erp.Skeleton.Domain.Enums.TipoStatusEnum;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Contrato : Entity
    {
        public Guid VendedorId { get; set; }
        public Guid ParceiroId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid FormaPagamentoId { get; set; }
        public Guid OrcamentoId { get; set; }
        public int OrdemServico { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string Doc { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public int QuantidadeProduto { get; set; }
        public string FirebaseId { get; set; }
        public string CodigoInstalacao { get; set; }
        public string CodigoContratoParceiro { get; set; }
        public string CodigoProdutoParceiro { get; set; }
        public Status Status { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CanalVenda { get; set; }
        public string GestorVenda { get; set; }
        public string LojaVenda { get; set; }
        public string GrupoVenda { get; set; }
        public string UrlContrato { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Parceiro Parceiro { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
    }
}