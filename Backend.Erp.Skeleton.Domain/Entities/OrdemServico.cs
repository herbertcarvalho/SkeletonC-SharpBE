using Backend.Erp.Skeleton.Domain.Extensions;
using System;
using System.Collections.Generic;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class OrdemServico : Entity
    {
        public Guid ContratoId { get; set; }
        public Guid InstaladorId { get; set; }
        //public ICollection<Contrato> Contratos { get; set; }
    }
}