using DiabeticsSystem.BlazorUI.Features.Product.Data.Repository;
using DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HttpClient Http;
        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(HttpClient http)
        {
            Http = http;
            ProductRepository = new ProductRepository(Http);
        }
    }
}
