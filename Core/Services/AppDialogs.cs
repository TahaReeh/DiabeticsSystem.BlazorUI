using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Core.Services
{
    public class AppDialogs
    {
        public static async Task<DialogResult> MessageBoxDelete(string title, IDialogService DialogService)
        {
            var dialog = await DialogService.ShowDialogAsync<FluentMessageBoxDeleteWidget>(new DialogParameters()
            {
                Title =title,
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            });
            
            return await dialog.Result;
        }

        public static async Task<DialogResult> MessageBoxConfirm(string title,string action, IDialogService DialogService)
        {
            var dialog = await DialogService.ShowDialogAsync<FluentMessageBoxConfirmWidget>(new DialogParameters()
            {
                Title = title,
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
                AriaLabel = action,
            });
            return await dialog.Result;
        }
    }
}
