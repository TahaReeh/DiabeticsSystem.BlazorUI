

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string route);
        Task<T> GetAsync(string route, Guid? id);
        Task<string> AddAsync(string route, T entity);
        Task RemoveAsync(string route,Guid? id);
    }
}
