using System.Text.Json.Serialization;

namespace Backend.Erp.Skeleton.Domain.Enums
{
    public class TipoStatusEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Status
        {
            Ativo = 0,
            Inativo = 1,
            Realizado = 2,
            Cancelado = 3,
            Reagendado = 4
        }
    }
}
