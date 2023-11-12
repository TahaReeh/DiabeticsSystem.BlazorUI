using AutoMapper;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase
{
    public interface ICustomerUsecase
    {
        Task<IQueryable<CustomerEntity>> GetAllCustomer();
    }

    public class CustomerUsecase : ICustomerUsecase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerUsecase(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<IQueryable<CustomerEntity>> GetAllCustomer()
        {
            var request = await unitOfWork.CustomerRepository.GetAllAsync(EndPoints.GetAllCustomers);
            var dto = mapper.Map<List<CustomerEntity>>(request).AsQueryable();
            return dto;
        }
    }
}
