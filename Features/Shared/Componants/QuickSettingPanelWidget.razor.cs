using DiabeticsSystem.BlazorUI.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI.DesignTokens;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Componants
{
    public partial class QuickSettingPanelWidget
    {
        [Inject]
        BaseLayerLuminance BaseLayerLuminances { get; set; } = default!;

        [Inject]
        AccentBaseColor AccentBaseColors { get; set; } = default!;

        //[Inject]
        //private ICookie cookie { get; set; } = default!;

        private OfficeColor _color = OfficeColor.Default;

        private bool _isDark = false;

        //protected override async Task OnInitializedAsync()
        //{
            //var accentValue = await cookie.GetValue("myAccentColor");
            //var themeMode = await cookie.GetValue("myThemeMode");
        //}
        public OfficeColor Color
        {
            get => _color;
            set
            {
                _color = value == OfficeColor.Default ? OfficeColor.Word : value;

                var colorHex = _color.ToAttributeValue() ?? "default";
                _ = AccentBaseColors.WithDefault(colorHex.ToSwatch());
            }
        }

        public bool IsDark
        {
            get => _isDark;
            set
            {
                _isDark = value;

                float luminance = _isDark ? (float)0.15 : 1;
                _ = BaseLayerLuminances.WithDefault(luminance);
            }
        }
    }
}
