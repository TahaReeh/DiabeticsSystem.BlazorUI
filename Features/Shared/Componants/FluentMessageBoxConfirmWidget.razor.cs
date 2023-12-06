namespace DiabeticsSystem.BlazorUI.Features.Shared.Componants
{
    public partial class FluentMessageBoxConfirmWidget
    {
        [Parameter]
        public bool Loading {  get; set; }

        [Parameter]
        public string ThisAction { get; set; } = string.Empty;

        [CascadingParameter]
        public FluentDialog Dialog { get; set; } = default!;

        public void CloseDialog()
        {
            Dialog.CancelAsync();
        }

        public void ConfirmDialog()
        {
            Dialog.CloseAsync();
        }
    }
}
