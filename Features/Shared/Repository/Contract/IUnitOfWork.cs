using DiabeticsSystem.BlazorUI.Features.Product.Data.Repository;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
