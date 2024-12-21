namespace BlazorWebProfile.Models;

public class TypingAnimation
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Font { get; set; } = "Fira Code";
    public int Size { get; set; }
    public int Duration { get; set; }
    public int Pause { get; set; }
    public string DarkColor { get; set; } = "F7F7F7";
    public string LightColor { get; set; } = "000000";
    public int Width { get; set; }
    public List<string> Lines { get; set; } = new();
}
