using Backend.Erp.Skeleton.Domain.Extensions;
using static Backend.Erp.Skeleton.Domain.Enums.TipoClienteEnum;
using static Backend.Erp.Skeleton.Domain.Enums.TipoStatusEnum;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Parceiro : Entity
    {
        public string Nome { get; set; }
        public string Doc { get; set; }
        public TipoCliente TipoCliente { get; set; }   
        public Status Status { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}