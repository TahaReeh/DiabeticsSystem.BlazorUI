using DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HttpClient Http;
        public Repository(HttpClient http)
        {
            Http = http;
        }
        public async Task<IEnumerable<T>> GetAll(string route)
        {
            return (await Http.GetFromJsonAsync<IEnumerable<T>>(route))!;
        }
    }
}
