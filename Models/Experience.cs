namespace BlazorWebProfile.Models;

public class Experience
{
    public string Company { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public Color Color { get; set; } = MudBlazor.Color.Info;
    public List<string> Details { get; set; } = new();
}
