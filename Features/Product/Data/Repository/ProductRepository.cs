using DiabeticsSystem.BlazorUI.Features.Shared.Repository;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Product.Data.Repository
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(HttpClient http) : base(http)
        {
        }
    }
}
