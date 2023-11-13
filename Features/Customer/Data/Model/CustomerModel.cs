using DiabeticsSystem.BlazorUI.Features.Shared.Common;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Data.Model
{
    public class CustomerModel :AuditableEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public string? SecondPhone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PersonalId { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Sex { get; set; }
        //public GenderEnum Gender { get; set; }
    }
}
