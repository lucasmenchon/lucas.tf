using Microsoft.JSInterop;

namespace BlazorWebProfile.Models;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;

    public bool DarkMode { get; set; } = true;

    public MudTheme CustomTheme { get; set; } = null!;

    public event Action<bool>? OnThemeChanged;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        InitializeTheme();
        InitializeCustomTheme();
    }

    private void InitializeCustomTheme()
    {
        CustomTheme = new MudTheme()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = Colors.Blue.Default,              // Azul principal vibrante
                Secondary = Colors.LightBlue.Lighten2,      // Azul claro de destaque
                Tertiary = Colors.LightBlue.Darken4,       // Azul bem suave para elementos
                Background = Colors.Shades.White,           // Fundo branco puro
                Surface = Colors.Gray.Lighten5,             // Fundo dos cards próximo ao branco
                AppbarBackground = Colors.Blue.Lighten2,    // AppBar em azul claro suave
                TextPrimary = Colors.Gray.Darken3,          // Texto principal em cinza escuro
                TextSecondary = Colors.Gray.Darken1,        // Texto secundário em cinza médio
                ActionDefault = Colors.Blue.Accent1,        // Ações em azul vibrante
                TableHover = Colors.LightBlue.Lighten3,     // Hover em azul suave
                Divider = Colors.Gray.Lighten2              // Divisores sutis
            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.Blue.Accent3,              // Azul vibrante no dark mode
                Secondary = Colors.LightBlue.Accent4,       // Azul mais claro para destaque
                Tertiary = Colors.Blue.Lighten4,             // Azul bem escuro para elementos
                Background = Colors.Shades.Black,           // Fundo preto puro
                Surface = Colors.Gray.Darken4,              // Fundo dos cards preto puxado
                AppbarBackground = Colors.Gray.Darken3,     // AppBar com cinza profundo
                TextPrimary = Colors.Gray.Lighten5,         // Texto branco claro
                TextSecondary = Colors.Gray.Lighten3,       // Texto secundário em cinza claro
                ActionDefault = Colors.Blue.Accent2,        // Ações com azul vibrante
                TableHover = Colors.Blue.Darken2,           // Hover em azul escuro
                Divider = Colors.Gray.Darken2               // Divisores em cinza escuro
            }
        };
    }

    public async void ToggleTheme()
    {
        DarkMode = !DarkMode;
        OnThemeChanged?.Invoke(DarkMode);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "DarkMode", DarkMode);
    }

    private async void InitializeTheme()
    {
        var storedTheme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "DarkMode");
        if (bool.TryParse(storedTheme, out var result))
        {
            DarkMode = result;
        }
    }
}
