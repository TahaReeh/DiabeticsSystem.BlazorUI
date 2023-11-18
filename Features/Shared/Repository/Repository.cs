using DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract;
using System.Net.Http;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HttpClient _http;
        public Repository(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string route)
        {
            return (await _http.GetFromJsonAsync<IEnumerable<T>>(route))!;
        }

        public async Task<T> GetAsync(string route, Guid? id)
        {
            return (await _http.GetFromJsonAsync<T>($"{route}{id}"))!;
        }

        public async Task<string> AddAsync(string route,T entity)
        {
            var response = await _http.PostAsJsonAsync(route, entity);
            //response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task RemoveAsync(string route, Guid? id)
        {
            var response =  await _http.DeleteAsync($"{route}{id}");
            response.EnsureSuccessStatusCode();

        }
    }
}
