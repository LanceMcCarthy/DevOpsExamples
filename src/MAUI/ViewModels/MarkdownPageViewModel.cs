using System.Collections.ObjectModel;
using CommonHelpers.Common;

namespace MauiDemo.ViewModels;

public class MarkdownPageViewModel : ViewModelBase
{
    public MarkdownPageViewModel()
    {
        for (var i = 0; i < 30; i++)
        {
            KbArticles.Add(new KbArticle()
            {
                DisplayName = $"Article {i}",
                FilePath = $"{i}.md"
            });
        }

        SelectedKbArticle = KbArticles.FirstOrDefault();
    }

    public string MarkdownText
    {
        get;
        set => SetProperty(ref field, value);
    }

    public ObservableCollection<KbArticle> KbArticles { get; set; } = [];

    public KbArticle? SelectedKbArticle
    {
        get;
        set => SetProperty(ref field, value, onChanged: async () =>
        {
            if (field == null || string.IsNullOrEmpty(field.FilePath))
                return;

            await LoadMarkdownAsync(field.FilePath);
        });
    }

    private async Task LoadMarkdownAsync(string path)
    {
        try
        {
            await using var stream = await FileSystem.OpenAppPackageFileAsync(path);
            using var reader = new StreamReader(stream);
            MarkdownText = await reader.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            MarkdownText = $"# Error\n\nCould not load {path}:\n\n```\n{ex.Message}\n```";
        }
    }
}

public class KbArticle
{
    public required string DisplayName { get; set; }

    public required string FilePath { get; set; }
}