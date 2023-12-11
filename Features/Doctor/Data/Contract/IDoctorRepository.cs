using DiabeticsSystem.BlazorUI.Features.Doctor.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Doctor.Data.Contract
{
    public interface IDoctorRepository : IRepository<DoctorModel>
    {
        Task UpdateAsync(string route, DoctorModel entity);
    }
}
