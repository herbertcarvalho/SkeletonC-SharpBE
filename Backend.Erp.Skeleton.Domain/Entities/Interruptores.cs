using Backend.Erp.Skeleton.Domain.Extensions;
using System;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Interruptores : Entity
    {
        public Guid OrcamentoId { get; set; }
        public int InterruptorParaAutomatizar { get; set; }
        public int InterruptorAfastado { get; set; }
        public int TomadasParaAutomatizar { get; set; }
    }
}