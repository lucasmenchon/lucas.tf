namespace BlazorWebProfile.Helpers;

public static class Utils
{
    public static string GetIcon(string iconName)
    {
        return iconName switch
        {
            "GitHub" => Icons.Custom.Brands.GitHub,
            "LinkedIn" => Icons.Custom.Brands.LinkedIn,
            "Telegram" => Icons.Custom.Brands.Telegram,
            "WhatsApp" => Icons.Custom.Brands.WhatsApp,
            "Email" => Icons.Material.Filled.Email,
            "Smartphone" => Icons.Material.Filled.Smartphone,
            _ => Icons.Material.Filled.Link
        };
    }
}
