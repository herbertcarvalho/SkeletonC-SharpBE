namespace Backend.Erp.Skeleton.Application.DTOs.Request
{
    public class ProdutoRequest
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}