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

        [Parameter]
        public bool Visible { get; set; } = false;

        public Align alignment = Align.Center;

        public JustifyContent justification = JustifyContent.Center;
    }
}
