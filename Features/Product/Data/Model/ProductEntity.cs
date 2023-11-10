using DiabeticsSystem.BlazorUI.Features.Shared.Common;

namespace DiabeticsSystem.BlazorUI.Features.Product.Data.Model
{
    public class ProductEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
    }
}
