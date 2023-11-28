using System;

namespace Backend.Erp.Skeleton.Application.DTOs.Response
{
    public class ExtensionData
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
    }
}