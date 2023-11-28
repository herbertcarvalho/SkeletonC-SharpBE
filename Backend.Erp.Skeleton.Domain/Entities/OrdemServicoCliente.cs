using Backend.Erp.Skeleton.Domain.Extensions;
using System;
using System.Collections.Generic;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class OrdemServicoCliente : Entity
    {
        public Guid OrdemServicoId { get; set; }
        public Guid ClienteId { get; set; }
        public virtual ICollection<OrdemServico> OrdemServicos { get; set; }
    }
}