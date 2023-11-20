using DiabeticsSystem.BlazorUI.Features.Home.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Home.Domain.Repository
{
    public class SystemSettingRepository(HttpClient http) : Repository<SystemSettingsVM>(http), ISystemSettingRepository
    {
        public async Task<SystemSettingsVM> TempGetUserSystemSettings(string route, string userId) => 
            (await _http.GetFromJsonAsync<SystemSettingsVM>($"{route}{userId}"))!;

        public async Task UpdateAsync(string route, SystemSettingsVM entity)
        {
            await _http.PutAsJsonAsync(route, entity);
        }
    }
}
