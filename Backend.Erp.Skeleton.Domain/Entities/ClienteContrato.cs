using Backend.Erp.Skeleton.Domain.Extensions;
using System;
using System.Collections.Generic;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class ClienteContrato : Entity
    {
        public Guid ClienteId { get; set; }
        public Guid ContratoId { get; set; }
        //public ICollection<Contrato> Contratos { get; set; }
    }
}