using Backend.Erp.Skeleton.Domain.Extensions;
using System;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Imovel : Entity
    {
        public Guid OrcamentoId { get; set; }
        public int TipoImovel { get; set; }
        public int Comodos { get; set; }
        public int Andares { get; set; }
        public int MetroQuadrado { get; set; }
    }
}