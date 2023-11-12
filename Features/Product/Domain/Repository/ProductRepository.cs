using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Repository;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Product.Domain.Repository
{
    public class ProductRepository : Repository<ProductModel>, IProductRepository
    {
        public ProductRepository(HttpClient http) : base(http)
        {
        }

        public async Task UpdateAsync(string route,ProductModel entity)
        {
            await _http.PutAsJsonAsync(route, entity);
            //response.EnsureSuccessStatusCode();
        }
    }
}
