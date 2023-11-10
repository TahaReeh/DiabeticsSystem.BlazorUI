using AutoMapper;
using DiabeticsSystem.BlazorUI.Core.Constants;
using DiabeticsSystem.BlazorUI.Features.Product.Data.ViewModels;
using DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract;

namespace DiabeticsSystem.BlazorUI.Features.Product.Data
{
    public interface IProductUsecase
    {
        Task<IQueryable<ProductVM>> GetAllProduct();
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
        public async Task<IQueryable<ProductVM>> GetAllProduct()
        {
            var request = await unitOfWork.ProductRepository.GetAll(EndPoints.GetAllProducts);
            var dto = (mapper.Map<List<ProductVM>>(request)).AsQueryable();
            return dto;
        }
    }
}
