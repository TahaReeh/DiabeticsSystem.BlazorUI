using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Home.Domain.Usecase
{
    public interface ISystemSettingsUsecase
    {
        Task<SystemSettingsVM> GetUserSystemSettings(string userId);
        Task UpdateUserSettings(SystemSettingsVM entity);
    }
    public class SystemSettingsUsecase(IUnitOfWork unitOfWork) : ISystemSettingsUsecase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

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
