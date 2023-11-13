namespace DiabeticsSystem.BlazorUI.Core.Services
{
    public class AppToast
    {
        public static void ShowSuccessToast(string message, IToastService ToastService)
        {
            ToastService.ShowToast(
                ToastIntent.Success,
                $"{message} successfuly"
            );
        }

        public static void ShowErrorToast(IToastService ToastService)
        {
            ToastService.ShowToast(
                ToastIntent.Error,
                "Somthing went wrong!"
            );
        }

        public static void ShowCustomErrorToast(string message, IToastService ToastService)
        {
            ToastService.ShowToast(
                ToastIntent.Error,
                message
            );
        }
    }
}
