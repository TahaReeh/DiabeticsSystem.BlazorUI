﻿using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.Home.Data.Contract
{
    public interface IHomeRepository : IRepository<SystemSettingsVM>
    {
        Task<SystemSettingsVM> TempGetUserSystemSettings(string route, string userId);
        Task<HomeAnalyticsVM> GetHomeAnalytics(string route);
        Task UpdateAsync(string route, SystemSettingsVM entity);
    }
}
