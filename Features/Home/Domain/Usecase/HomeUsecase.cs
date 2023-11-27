using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Home.Domain.Usecase
{
    public interface IHomeUsecase
    {
        Task<SystemSettingsVM> GetUserSystemSettings(string userId);
        Task<HomeAnalyticsVM> GetHomeAnalytics();
        Task UpdateUserSettings(SystemSettingsVM entity);
    }
    public class HomeUsecase(IUnitOfWork unitOfWork) : IHomeUsecase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<HomeAnalyticsVM> GetHomeAnalytics()
        {
            return await _unitOfWork.SystemSettingRepository.GetHomeAnalytics(EndPoints.GetHomeAnalytics);
        }

        public async Task<SystemSettingsVM> GetUserSystemSettings(string userId)
        {
            return await _unitOfWork.SystemSettingRepository.TempGetUserSystemSettings(EndPoints.GetUserSystemSettings, userId);
        }

        public async Task UpdateUserSettings(SystemSettingsVM entity)
        {
            await _unitOfWork.SystemSettingRepository.UpdateAsync(EndPoints.UpdateUserSystemSettings, entity);
        }
    }
}
