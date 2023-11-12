using DiabeticsSystem.BlazorUI.Features.Shared.Common;
using System.ComponentModel.DataAnnotations;

namespace DiabeticsSystem.BlazorUI.Features.Product.Data.Model
{
    public class ProductModel : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public required string Details { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
    }
}
