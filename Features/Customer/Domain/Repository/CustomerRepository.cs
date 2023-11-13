using DiabeticsSystem.BlazorUI.Features.Customer.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Domain.Repository
{
    public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(HttpClient http) : base(http)
        {
        }

        public async Task UpdateAsync(string route, CustomerModel entity)
        {
            await _http.PutAsJsonAsync(route, entity);
        }
    }
}
