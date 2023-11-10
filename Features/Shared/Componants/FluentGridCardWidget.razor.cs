using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Componants
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
