using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Componants
{
    public partial class FluentGridCardWidget
    {
        [Parameter]
        public EventCallback OnBtnMainClick { get; set; }

        [Parameter]
        public EventCallback OnBtnExportCsvClick { get; set; }

        [Parameter]
        public bool IncludeMainBtn { get; set; }

        [Parameter]
        public bool IncludeExportCsvBtn { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public RenderFragment? RawTemplate { get; set; }

        public Align alignment = Align.Center;

        public JustifyContent justification = JustifyContent.Center;

        [Parameter]
        public bool Visible { get; set; } = false;
    }
}
