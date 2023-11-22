namespace DiabeticsSystem.BlazorUI.Features.Home.Data.Model
{
    public class SystemSettingsVM
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int AccentColor { get; set; }
        public bool IsDark { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
