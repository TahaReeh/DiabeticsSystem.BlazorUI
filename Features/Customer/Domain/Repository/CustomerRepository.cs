using DiabeticsSystem.BlazorUI.Features.Customer.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Domain.Repository
{
    public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(HttpClient http) : base(http)
        {
        }
    }
}
