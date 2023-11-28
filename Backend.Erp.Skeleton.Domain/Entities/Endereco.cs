using Backend.Erp.Skeleton.Domain.Extensions;
using System;

namespace Backend.Erp.Skeleton.Domain.Entities
{
    public class Endereco : Entity
    {
        public Guid? ClienteId { get; set; }
        public Guid? VendedorId { get; set; }
        public Guid? ParceiroId { get; set; }
        public Guid? InstaladorId { get; set; }
        public int Cep { get; set; }
        public int Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
    }
}