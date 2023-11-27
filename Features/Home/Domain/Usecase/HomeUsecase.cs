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
            return await _unitOfWork.HomeRepository.GetHomeAnalytics(EndPoints.GetHomeAnalytics);
        }

        public async Task<SystemSettingsVM> GetUserSystemSettings(string userId)
        {
            return await _unitOfWork.HomeRepository.TempGetUserSystemSettings(EndPoints.GetUserSystemSettings, userId);
        }

        public async Task UpdateUserSettings(SystemSettingsVM entity)
        {
            await _unitOfWork.HomeRepository.UpdateAsync(EndPoints.UpdateUserSystemSettings, entity);
        }
    }
}
