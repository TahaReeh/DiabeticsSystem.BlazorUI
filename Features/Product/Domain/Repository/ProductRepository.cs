using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Repository;

namespace DiabeticsSystem.BlazorUI.Features.Product.Domain.Repository
{
    public class ProductRepository : Repository<ProductModel>, IProductRepository
    {
        public ProductRepository(HttpClient http) : base(http)
        {
        }
    }
}
