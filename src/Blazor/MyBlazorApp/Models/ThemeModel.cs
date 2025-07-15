namespace MyBlazorApp.Models;

public class ThemeModel(int id, string themeName, string swatchName)
{
    public int Id { get; set; } = id;
    public string Theme { get; set; } = themeName;
    public string Swatch { get; set; } = swatchName;
    public string FullName => $"{Theme} {Swatch}";
}