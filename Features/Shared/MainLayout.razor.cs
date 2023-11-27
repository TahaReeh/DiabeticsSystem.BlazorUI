using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Core.SharedResources;
using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Home.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Shared.Componants;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI.DesignTokens;

namespace DiabeticsSystem.BlazorUI.Features.Shared
{
    public partial class MainLayout
    {
        [Inject]
        private IHomeUsecase Usecase { get; set; } = default!;
        [Inject]
        private IDialogService DialogService { get; set; } = default!;
        [Inject]
        public IToastService ToastService { get; set; } = default!;
        [Inject]
        BaseLayerLuminance BaseLayerLuminances { get; set; } = default!;
        [Inject]
        AccentBaseColor AccentBaseColors { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await FetchSystemSettingsData();
        }

        private async Task FetchSystemSettingsData()
        {
            SessionStore.StaticSettingsVM = await Usecase.GetUserSystemSettings("UserId");

            var _color = (OfficeColor)SessionStore.StaticSettingsVM.AccentColor;
            await AccentBaseColors.WithDefault(_color.GetDescription()!.ToSwatch());


            float luminance = SessionStore.StaticSettingsVM.IsDark ? (float)0.15 : 1;
            await BaseLayerLuminances.WithDefault(luminance);
        }

        public async Task OpenQuickSettingAsync()
        {
            DialogParameters<string> parameters = new()
            {
                Title = "Quick Settings",
                Alignment = HorizontalAlignment.Right,
                OnDialogResult = DialogService.CreateDialogCallback(this, HandleQuickSetting),
                PreventDismissOnOverlayClick = true,
                PrimaryAction = "Save",
                SecondaryAction = "Cancel",
            };
            await DialogService.ShowPanelAsync<QuickSettingPanelWidget>(parameters);
        }

        private async Task HandleQuickSetting(DialogResult result)
        {
            if (!result.Cancelled)
            {
                if (result.Data is not null)
                {
                    var obj = SessionStore.StaticSettingsVM;
                    await Usecase.UpdateUserSettings(obj);
                    AppToast.ShowSuccessToast("Settings saved", ToastService);
                }
            }
        }
    }
}
