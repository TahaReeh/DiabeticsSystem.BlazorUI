using DiabeticsSystem.BlazorUI.Features.Shared.Common;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Data.Model
{
    public class CustomerModel :AuditableEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? SecondPhone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PersonalId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Sex { get; set; }
    }
}
