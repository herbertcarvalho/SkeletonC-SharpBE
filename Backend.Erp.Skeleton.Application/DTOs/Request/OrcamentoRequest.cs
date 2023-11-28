using System;
using static Backend.Erp.Skeleton.Domain.Enums.TipoClienteEnum;

namespace Backend.Erp.Skeleton.Application.DTOs.Request
{
    public class OrcamentoRequest
    {
        public string EmpresaNome { get; set; }
        public string Cnpj { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string DocCliente { get; set; }
        public string NomeCliente { get; set; }
        public string ContatoCliente { get; set; }
        public DateTime Vallidade { get; set; }
        public int TipoImovel { get; set; }
        public int Comodos { get; set; }
        public int Andares { get; set; }
        public int MetroQuadrado { get; set; }
        public int SalaComAparelho { get; set; }
        public int QuartoComAparelho { get; set; }
        public int ExternoComAparelho { get; set; }
        public int InterruptorParaAutomatizar { get; set; }
        public int InterruptorAfastado { get; set; }
        public int TomadasParaAutomatizar { get; set; }
    }
}