using AutoMapper;
using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase
{
    public interface ICustomerUsecase
    {
        Task<IQueryable<CustomerEntity>> GetAllCustomer();
        Task<CustomerModel> GetCustomerDetail(Guid? id);
        Task<string> AddCustomer(CustomerModel entity);
        Task RemoveCustomer(Guid? id);
        Task UpdateCustomer(CustomerModel entity);
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

        public async Task<CustomerModel> GetCustomerDetail(Guid? id) =>
            await unitOfWork.CustomerRepository.GetAsync(EndPoints.GetCustomer, id);

        public async Task<string> AddCustomer(CustomerModel entity)
        {
            return await unitOfWork.CustomerRepository.AddAsync(EndPoints.AddCustomer, entity);
        }

        public async Task RemoveCustomer(Guid? id)
        {
            await unitOfWork.CustomerRepository.RemoveAsync(EndPoints.RemoveCustomer, id);
        }

        public async Task UpdateCustomer(CustomerModel entity)
        {
            await unitOfWork.CustomerRepository.UpdateAsync(EndPoints.UpdateCustomer, entity);
        }
    }
}
