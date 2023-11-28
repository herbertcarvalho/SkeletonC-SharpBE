using Backend.Erp.Skeleton.Domain.Extensions;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Produto : Entity
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public int? Cubagem { get; set; }
        public int? Peso { get; set; }
        public int? Altura { get; set; }
        public int? Largura { get; set; }
    }
}