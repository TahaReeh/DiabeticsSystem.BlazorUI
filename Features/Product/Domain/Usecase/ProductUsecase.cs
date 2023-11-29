using DiabeticsSystem.BlazorUI.Core.Profiles;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;

namespace DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase
{
    public interface IProductUsecase
    {
        Task<IQueryable<ProductEntity>> GetAllProduct();
        Task<ProductModel> GetProductDetail(Guid? id);
        Task<string> AddProduct(ProductModel product);
        Task RemoveProduct(Guid? id);
        Task UpdateProduct(ProductModel entity);
    }

    public class ProductUsecase : IProductUsecase
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductUsecase(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<IQueryable<ProductEntity>> GetAllProduct()
        {
            var request = (await unitOfWork.ProductRepository.GetAllAsync(EndPoints.GetAllProducts));
            var dto = request.Select(x => x.MapProductFromModel());
            return dto.AsQueryable();
        }

        public async Task<ProductModel> GetProductDetail(Guid? id) =>
            await unitOfWork.ProductRepository.GetAsync(EndPoints.GetProduct, id);


        public async Task<string> AddProduct(ProductModel entity)
        {
            return await unitOfWork.ProductRepository.AddAsync(EndPoints.AddProduct, entity);
        }

        public async Task RemoveProduct(Guid? id)
        {
            await unitOfWork.ProductRepository.RemoveAsync(EndPoints.RemoveProduct, id);
        }

        public async Task UpdateProduct(ProductModel entity)
        {
            await unitOfWork.ProductRepository.UpdateAsync(EndPoints.UpdateProduct, entity);
        }
    }
}
