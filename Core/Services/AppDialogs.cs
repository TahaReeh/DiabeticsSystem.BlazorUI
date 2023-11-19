using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Core.Services
{
    public class AppDialogs
    {
        public static async Task<DialogResult> MessageBoxDelete(string title, IDialogService DialogService)
        {
            var dialog = await DialogService.ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
            {
                Content = new()
                {
                    Title = $"Delete {title}",
                    MarkupMessage = new MarkupString($"Do you want to <strong>Delete</strong> this {title}?"),
                    Icon = new Icons.Regular.Size24.Delete(),
                    IconColor = Color.Error,
                },
                PrimaryAction = "Yes",
                SecondaryAction = "No",
             
            });
            return await dialog.Result;
        }

        public static async Task<DialogResult> MessageBoxConfirm(string title,string action, IDialogService DialogService)
        {
            var dialog = await DialogService.ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
            {
                Content = new()
                {
                    Title = $"{action} {title}",
                    MarkupMessage = new MarkupString($"Do you want to <strong>{action}</strong> this {title}?"),
                    Icon = new Icons.Regular.Size24.QuestionCircle(),
                    IconColor = Color.Accent,
                },
                PrimaryAction = "Yes",
                SecondaryAction = "No",
            });
            return await dialog.Result;
        }
    }
}
