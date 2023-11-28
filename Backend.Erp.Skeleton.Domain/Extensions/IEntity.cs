using System;

namespace Backend.Erp.Skeleton.Domain.Extensions
{
    internal interface IEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}