using DiabeticsSystem.BlazorUI.Features.Home.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Home.Domain.Repository
{
    public class HomeRepository(HttpClient http) : Repository<SystemSettingsVM>(http), IHomeRepository
    {
        public async Task<HomeAnalyticsVM> GetHomeAnalytics(string route) =>
            (await _http.GetFromJsonAsync<HomeAnalyticsVM>(route))!;


        public async Task<SystemSettingsVM> TempGetUserSystemSettings(string route, string userId) => 
            (await _http.GetFromJsonAsync<SystemSettingsVM>($"{route}{userId}"))!;

        public async Task UpdateAsync(string route, SystemSettingsVM entity)
        {
            await _http.PutAsJsonAsync(route, entity);
        }
    }
}
