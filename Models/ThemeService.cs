using MudBlazor;

namespace BlazorWebProfile.Models
{
    public class ThemeService
    {
        public bool DarkMode { get; set; } = false;

        public MudTheme CustomTheme => new MudTheme()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#6C63FF",
                Secondary = "#8E7AB5",
                Tertiary = "#B8C1EC",
                Background = "#F4F4F8",
                Surface = "#FFFFFF",
                AppbarBackground = "#6C63FF",
                TextPrimary = "#2D2D2D",
                TextSecondary = "#6C757D",
                ActionDefault = "#8E7AB5",
                TableHover = "#E0E7FF",
                Divider = "#B8C1EC"
            },
            PaletteDark = new PaletteDark()
            {
                Primary = "#8E7AB5",
                Secondary = "#6C63FF",
                Tertiary = "#B8C1EC",
                Background = "#121212",
                Surface = "#1E1E2E",
                AppbarBackground = "#1E1E2E",
                TextPrimary = "#FFFFFF",
                TextSecondary = "#D1D5DB",
                ActionDefault = "#6C63FF",
                TableHover = "#6E7582",
                Divider = "#4B4B6F"
            }
        };

        public event Action<bool>? OnThemeChanged;

        public ThemeService()
        {
            DarkMode = true;
        }

        public void ToggleTheme()
        {
            DarkMode = !DarkMode;
            OnThemeChanged?.Invoke(DarkMode);
        }
    }
}
