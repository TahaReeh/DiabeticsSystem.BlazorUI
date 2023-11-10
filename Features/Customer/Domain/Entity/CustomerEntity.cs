namespace DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
