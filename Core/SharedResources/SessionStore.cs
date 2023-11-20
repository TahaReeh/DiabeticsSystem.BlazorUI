using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;

namespace DiabeticsSystem.BlazorUI.Core.SharedResources
{
    public static class SessionStore
    {
        public static SystemSettingsVM StaticSettingsVM { get; set; } = new();
    }
}
