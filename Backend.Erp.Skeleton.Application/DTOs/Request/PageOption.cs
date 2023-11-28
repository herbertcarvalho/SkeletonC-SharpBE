using System.ComponentModel.DataAnnotations;

namespace Backend.Erp.Skeleton.Application.DTOs.Request
{
    public class PageOption
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Page { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }
    }
}