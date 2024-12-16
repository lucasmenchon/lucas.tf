namespace BlazorWebProfile.Models
{
    public class ThemeService
    {
        public bool DarkMode { get; set; } = false;

        public MudTheme CustomTheme => new MudTheme()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = Colors.Blue.Darken2,
                Secondary = Colors.DeepPurple.Darken1,
                Background = Colors.Gray.Lighten4,
                AppbarBackground = Colors.Blue.Darken3,
                TextPrimary = Colors.Gray.Darken4
            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.Blue.Lighten3,
                Secondary = Colors.Purple.Lighten2,
                Background = Colors.Gray.Darken4,
                AppbarBackground = Colors.Gray.Darken3,
                TextPrimary = Colors.Gray.Lighten1
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
