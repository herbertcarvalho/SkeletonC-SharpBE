namespace Backend.Erp.Skeleton.Application.DTOs.Response
{
    public class ProdutoResponse : ExtensionData
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}