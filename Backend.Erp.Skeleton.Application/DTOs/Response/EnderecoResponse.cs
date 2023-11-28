namespace Backend.Erp.Skeleton.Application.DTOs.Response
{
    public class EnderecoResponse : ExtensionData
    {
        public int Cep { get; set; }
        public int Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
    }
}