using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Product.Data.Repository
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        Task UpdateAsync(string route, ProductModel entity);
    }
}
