using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Core.SharedComponanats
{
    public partial class TableWidget<TItem>
    {
        [Parameter]
        public EventCallback OnClickCreate { get; set; }

        [Parameter]
        public RenderFragment? HeaderTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem>? RowTemplate { get; set; }

        [Parameter]
        public IReadOnlyList<TItem>? Items { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool Loading { get; set; }
    }
}
