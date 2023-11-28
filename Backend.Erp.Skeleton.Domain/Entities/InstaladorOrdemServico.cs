using Backend.Erp.Skeleton.Domain.Extensions;
using System;
using System.Collections.Generic;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class InstaladorOrdemServico : Entity
    {
        public Guid InstaladorId { get; set; }
        public Guid OrdemServicoId { get; set; }
        public virtual ICollection<OrdemServico> OrdemServicos { get; set; }
    }
}