using DiabeticsSystem.BlazorUI.Features.Doctor.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Doctor.Data.Model;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Repository
{
    public class DoctorRepository : Repository<DoctorModel>, IDoctorRepository
    {
        public DoctorRepository(HttpClient http) : base(http)
        {
        }

        public async Task UpdateAsync(string route, DoctorModel entity)
        {
            await _http.PutAsJsonAsync(route, entity);
        }
    }
}
