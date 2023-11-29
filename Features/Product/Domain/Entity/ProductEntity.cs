using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using System.Runtime.CompilerServices;

namespace DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

    }
}
