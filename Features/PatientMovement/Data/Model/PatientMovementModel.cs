using DiabeticsSystem.BlazorUI.Features.Shared.Common;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model
{
    public class PatientMovementModel : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public string? Barcode { get; set; }
        public CustomerDTO Customer { get; set; } = default!;
        public ProductDTO? Product { get; set; }
    }

    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
