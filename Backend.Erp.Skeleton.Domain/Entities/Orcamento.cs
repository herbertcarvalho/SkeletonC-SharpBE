using Backend.Erp.Skeleton.Domain.Extensions;
using System;
using static Backend.Erp.Skeleton.Domain.Enums.TipoClienteEnum;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Orcamento : Entity
    {
        public string EmpresaNome { get; set; }
        public string Cnpj { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string DocCliente { get; set; }
        public string NomeCliente { get; set; }
        public string ContatoCliente { get; set; }
        public DateTime Vallidade { get; set; }
        public virtual Imovel Imovel { get; set; }
        public virtual Aparelho Aparelho { get; set; }
        public virtual Interruptores Interruptores { get; set; }
    }
}