using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Componants
{
    public partial class QuickSettingPanelWidget
    {
        [Inject]
        BaseLayerLuminance BaseLayerLuminances { get; set; } = default!;

        [Inject]
        AccentBaseColor AccentBaseColors { get; set; } = default!;

        private OfficeColor _color = (OfficeColor)SessionStore.StaticSettingsVM.AccentColor;

        public OfficeColor Color
        {
            get => _color;
            set
            {
                _color = value == OfficeColor.Default ? OfficeColor.SharePoint : value;
                var colorHex = _color.GetDescription() ?? OfficeColor.SharePoint.GetDescription()!;

                _ = AccentBaseColors.WithDefault(colorHex.ToSwatch());

                SessionStore.StaticSettingsVM.AccentColor = (int)_color;
            }
        }

        public bool IsDark
        {
            get => SessionStore.StaticSettingsVM.IsDark;
            set
            {
                SessionStore.StaticSettingsVM.IsDark = value;

                float luminance = SessionStore.StaticSettingsVM.IsDark ? (float)0.15 : 1;
                _ = BaseLayerLuminances.WithDefault(luminance);
            }
        }

        public string Note
        {
            get => SessionStore.StaticSettingsVM.Notes;
            set => SessionStore.StaticSettingsVM.Notes = value;
        }
    }
}
