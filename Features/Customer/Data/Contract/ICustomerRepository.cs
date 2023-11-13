using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Data.Contract
{
    public interface ICustomerRepository : IRepository<CustomerModel>
    {
        Task UpdateAsync(string route, CustomerModel entity);
    }
}
