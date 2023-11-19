using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Entity;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Repository
{
    public class PatientMovementRepository(HttpClient http) : Repository<PatientMovementModel>(http), IPatientMovementRepository
    {
        public async Task<string> AddTest(string route, CreatePatientMovementEntity entity)
        {
            var response = await _http.PostAsJsonAsync(route, entity);
            //response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<PatientMovementModel>> GetPatientByCustomer(string route, Guid? id)
        {
            return (await _http.GetFromJsonAsync<IEnumerable<PatientMovementModel>>($"{route}{id}"))!;
        }

        public async Task<byte[]> GetPatientMovmentsCSV(string route)
        {
            var response = await _http.GetAsync(route);
            response.EnsureSuccessStatusCode();
            var fileBytes = await response.Content.ReadAsByteArrayAsync();
            return fileBytes;
        }
    }
}
