using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Core.SharedComponanats
{
    public partial class TableWidget<TItem>
    {
        [Parameter]
        public RenderFragment HeaderTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; }

        [Parameter]
        public string title { get; set; }
    }
}
