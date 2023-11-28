using Backend.Erp.Skeleton.Domain.Extensions;
using System;
using System.Collections.Generic;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class ContratoProduto : Entity
    {
        public Guid ContratoId { get; set; }
        public Guid ProdutoId { get; set; }
        public string MacAddress { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}