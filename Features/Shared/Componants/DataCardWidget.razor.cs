using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Componants
{
    public partial class DataCardWidget
    {
        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? RawTemplate { get; set; }

        [Parameter]
        public Icon? IconX { get; set; }
    }
}
