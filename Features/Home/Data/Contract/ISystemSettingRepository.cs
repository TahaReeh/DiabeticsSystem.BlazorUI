using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Home.Data.Contract
{
    public interface ISystemSettingRepository : IRepository<SystemSettingsVM>
    {
        Task<SystemSettingsVM> TempGetUserSystemSettings(string route, string userId);
        Task UpdateAsync(string route, SystemSettingsVM entity);
    }
}
