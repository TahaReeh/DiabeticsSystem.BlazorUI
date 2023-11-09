namespace DiabeticsSystem.BlazorUI.Features.Product.Domain.Entitiy
{
    public class ProductVM
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }
}
