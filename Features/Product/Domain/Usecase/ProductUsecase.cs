using AutoMapper;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;

namespace DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase
{
    public interface IProductUsecase
    {
        Task<IQueryable<ProductEntity>> GetAllProduct();
    }

    public class ProductUsecase : IProductUsecase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductUsecase(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<IQueryable<ProductEntity>> GetAllProduct()
        {
            var request = await unitOfWork.ProductRepository.GetAll(EndPoints.GetAllProducts);
            var dto = mapper.Map<List<ProductEntity>>(request).AsQueryable();
            return dto;
        }
    }
}
