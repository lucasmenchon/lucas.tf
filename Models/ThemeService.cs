using Microsoft.JSInterop;
using MudBlazor;

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
                Secondary = Colors.LightBlue.Darken4,      // Azul claro de destaque
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
                Primary = Colors.Indigo.Accent3,            // Índigo vibrante para botões e destaques
                Secondary = Colors.Blue.Accent2,           // Azul claro para contrastar em elementos secundários
                Tertiary = Colors.Blue.Lighten4,      // Roxo profundo para detalhes complementares

                // Fundo e Superfícies
                Background = Colors.Shades.Black,          // Fundo preto puro para contraste
                Surface = Colors.Gray.Darken4,             // Superfície escura, neutra e uniforme
                AppbarBackground = Colors.Gray.Darken3,    // Fundo da AppBar um pouco mais claro para leve separação visual

                // Textos
                TextPrimary = Colors.Blue.Lighten4,         // Texto principal em branco puro para contraste claro
                TextSecondary = Colors.Gray.Lighten2,      // Texto secundário em cinza claro
                ActionDefault = Colors.Indigo.Accent3,     // Ações principais com tom vibrante
                ActionDisabled = Colors.Gray.Darken2,      // Ações desativadas em cinza escuro
                ActionDisabledBackground = Colors.Gray.Darken4, // Fundo para ações desativadas

                // Ícones e Drawer
                DrawerBackground = Colors.Gray.Darken4,    // Fundo do Drawer alinhado às superfícies
                DrawerText = Colors.Shades.White,          // Texto no Drawer para destaque
                DrawerIcon = Colors.Indigo.Lighten3,       // Ícones no Drawer em tom claro para boa visualização

                // Linhas e Divisores
                Divider = Colors.Gray.Darken2,             // Divisores discretos e com contraste suficiente
                TableHover = Colors.Gray.Darken3,          // Hover em tabelas com tom levemente diferenciado

                // Mensagens de Status
                Success = Colors.Green.Accent3,            // Verde vibrante para mensagens de sucesso
                Warning = Colors.Amber.Accent2,            // Amarelo vibrante para avisos
                Error = Colors.Red.Accent2,                // Vermelho vibrante para erros
                Info = Colors.Cyan.Accent3,                // Azul claro para informações

                // Overlay e Sombras
                OverlayDark = Colors.Gray.Darken4,         // Overlay com tom escuro para modais
            }
            //Primary = Colors.Blue.Accent3,              // Azul vibrante no dark mode
            //Secondary = Colors.LightBlue.Accent4,       // Azul mais claro para destaque
            //Tertiary = Colors.Blue.Lighten4,             // Azul bem escuro para elementos
            //Background = Colors.Shades.Black,           // Fundo preto puro
            //Surface = Colors.Gray.Darken4,              // Fundo dos cards preto puxado
            //AppbarBackground = Colors.Gray.Darken4,     // AppBar com cinza profundo
            //TextPrimary = Colors.Blue.Lighten4,//Colors.Gray.Lighten5,         // Texto branco claro
            //TextSecondary = Colors.Gray.Lighten3,       // Texto secundário em cinza claro
            //ActionDefault = Colors.Blue.Accent2,        // Ações com azul vibrante
            //TableHover = Colors.Blue.Darken2,           // Hover em azul escuro
            //Divider = Colors.Gray.Darken2               // Divisores em cinza escuro
        
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
