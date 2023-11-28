using Backend.Erp.Skeleton.Domain.Extensions;
using System;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Aparelho : Entity
    {
        public Guid OrcamentoId { get; set; }
        public int SalaComAparelho { get; set; }
        public int QuartoComAparelho { get; set; }
        public int ExternoComAparelho { get; set; }
    }
}