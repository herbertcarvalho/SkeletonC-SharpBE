using System.Text.Json.Serialization;

namespace Backend.Erp.Skeleton.Domain.Enums
{
    public class TipoClienteEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum TipoCliente
        {
            Fisica = 0,
            Juridica = 1
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum TipoParceiro
        {
            Instalador = 0,
            Vendedor = 1
        }
    }
}
