using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.Shared.Componants;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Shared
{
    public partial class MainLayout
    {
        [Inject]
        private IDialogService DialogService { get; set; } = default!;
        [Inject]
        private ICookie cookie { get; set; } = default!;

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
            if (result.Cancelled)
            {
                return;
            }
            if (result.Data is not null)
            {
                string? _officeColor = result.Data as string;

                await cookie.SetValue("myAccentColor", _officeColor ?? "default");
            }
        }
    }
}
