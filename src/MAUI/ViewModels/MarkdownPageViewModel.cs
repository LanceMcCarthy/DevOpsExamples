using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiDemo.ViewModels;

public class MarkdownPageViewModel : INotifyPropertyChanged
{
    private string _markdownText = string.Empty;

    public string MarkdownText
    {
        get => _markdownText;
        set
        {
            if (_markdownText == value) return;
            _markdownText = value;
            OnPropertyChanged();
        }
    }

    public MarkdownPageViewModel()
    {
        _ = LoadReadmeAsync();
    }

    private async Task LoadReadmeAsync()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("readme.md");
            using var reader = new StreamReader(stream);
            MarkdownText = await reader.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            MarkdownText = $"# Error\n\nCould not load readme.md:\n\n```\n{ex.Message}\n```";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
