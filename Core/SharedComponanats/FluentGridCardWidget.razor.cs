using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace DiabeticsSystem.BlazorUI.Core.SharedComponanats
{
    public partial class FluentGridCardWidget
    {
        [Parameter]
        public EventCallback OnBtnMainClick { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public RenderFragment? RawTemplate { get; set; }

    }
}
