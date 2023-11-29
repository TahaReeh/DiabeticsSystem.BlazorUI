using DiabeticsSystem.BlazorUI.Core.Profiles;
using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;

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

        public CustomerUsecase(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<IQueryable<CustomerEntity>> GetAllCustomer()
        {
            var request = await unitOfWork.CustomerRepository.GetAllAsync(EndPoints.GetAllCustomers);
            var dto = request.Select(x => x.MapCustomerFromModel());
            return dto.AsQueryable();
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
            //await unitOfWork.GetRepository<CustomerEntity>().RemoveAsync(EndPoints.GetCustomer, id);
        }

        public async Task UpdateCustomer(CustomerModel entity)
        {
            await unitOfWork.CustomerRepository.UpdateAsync(EndPoints.UpdateCustomer, entity);
        }
    }
}
