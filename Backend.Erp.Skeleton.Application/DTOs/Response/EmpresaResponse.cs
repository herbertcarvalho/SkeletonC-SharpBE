using static Backend.Erp.Skeleton.Domain.Enums.TipoStatusEnum;

namespace Backend.Erp.Skeleton.Application.DTOs.Response
{
    public class EmpresaResponse : ExtensionData
    {
        public string Doc { get; set; }
        public string RazaoSocial { get; set; }
        public string CanalVenda { get; set; }
        public string Lojas { get; set; }
        public string GrupoVendedor { get; set; }
        public string CoordenadorGestor { get; set; }
        public Status Status { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}