

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string route);
    }
}
