using Markdig;
using Markdig.Extensions.AutoIdentifiers;

namespace MauiDemo.Controls;

/// <summary>
/// A custom control that renders Markdown content inside a WebView using Markdig for HTML conversion.
/// Supports headings, tables, code blocks, images, blockquotes, and inline HTML.
/// </summary>
public class MarkdownViewer : ContentView
{
    private readonly WebView _webView;

    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
        .UseAdvancedExtensions()
        .UseAutoIdentifiers(AutoIdentifierOptions.GitHub)
        .UseEmojiAndSmiley()
        .Build();

    public static readonly BindableProperty MarkdownTextProperty = BindableProperty.Create(
        nameof(MarkdownText),
        typeof(string),
        typeof(MarkdownViewer),
        defaultValue: string.Empty,
        propertyChanged: OnMarkdownTextChanged);

    public string MarkdownText
    {
        get => (string)GetValue(MarkdownTextProperty);
        set => SetValue(MarkdownTextProperty, value);
    }

    public MarkdownViewer()
    {
        _webView = new WebView
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
        };

        Content = _webView;
    }

    private static void OnMarkdownTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is MarkdownViewer viewer && newValue is string markdown)
        {
            viewer.RenderMarkdown(markdown);
        }
    }

    private void RenderMarkdown(string markdown)
    {
        var html = Markdown.ToHtml(markdown, Pipeline);
        var fullHtml = WrapInHtmlDocument(html);
        _webView.Source = new HtmlWebViewSource { Html = fullHtml };
    }

    private static string WrapInHtmlDocument(string bodyHtml) => $$"""
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0" />
            <style>
                :root {
                    --bg: #ffffff;
                    --fg: #24292f;
                    --muted: #57606a;
                    --border: #d0d7de;
                    --code-bg: #f6f8fa;
                    --link: #0969da;
                    --blockquote-border: #d0d7de;
                    --table-header-bg: #f6f8fa;
                    --table-row-alt: #f6f8fa;
                    --font: -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, Arial, sans-serif;
                    --font-mono: ui-monospace, SFMono-Regular, "SF Mono", Menlo, Consolas, monospace;
                }
                @media (prefers-color-scheme: dark) {
                    :root {
                        --bg: #0d1117;
                        --fg: #e6edf3;
                        --muted: #8b949e;
                        --border: #30363d;
                        --code-bg: #161b22;
                        --link: #58a6ff;
                        --blockquote-border: #3d444d;
                        --table-header-bg: #161b22;
                        --table-row-alt: #161b22;
                    }
                }
                * { box-sizing: border-box; margin: 0; padding: 0; }
                body {
                    font-family: var(--font);
                    font-size: 16px;
                    line-height: 1.6;
                    color: var(--fg);
                    background: var(--bg);
                    padding: 24px;
                    max-width: 900px;
                    margin: 0 auto;
                }
                h1, h2, h3, h4, h5, h6 {
                    margin-top: 24px;
                    margin-bottom: 12px;
                    font-weight: 600;
                    line-height: 1.25;
                }
                h1 { font-size: 2em; border-bottom: 1px solid var(--border); padding-bottom: 8px; }
                h2 { font-size: 1.5em; border-bottom: 1px solid var(--border); padding-bottom: 6px; }
                h3 { font-size: 1.25em; }
                p { margin-bottom: 16px; }
                a { color: var(--link); text-decoration: none; }
                a:hover { text-decoration: underline; }
                img { max-width: 100%; height: auto; border-radius: 4px; }
                code {
                    font-family: var(--font-mono);
                    font-size: 0.875em;
                    background: var(--code-bg);
                    border: 1px solid var(--border);
                    border-radius: 4px;
                    padding: 2px 6px;
                }
                pre {
                    background: var(--code-bg);
                    border: 1px solid var(--border);
                    border-radius: 6px;
                    padding: 16px;
                    overflow-x: auto;
                    margin-bottom: 16px;
                }
                pre code {
                    background: none;
                    border: none;
                    padding: 0;
                    font-size: 0.875em;
                }
                blockquote {
                    border-left: 4px solid var(--blockquote-border);
                    color: var(--muted);
                    padding: 4px 16px;
                    margin-bottom: 16px;
                }
                ul, ol { padding-left: 24px; margin-bottom: 16px; }
                li { margin-bottom: 4px; }
                table {
                    border-collapse: collapse;
                    width: 100%;
                    margin-bottom: 16px;
                    font-size: 0.9em;
                }
                th, td {
                    border: 1px solid var(--border);
                    padding: 8px 12px;
                    text-align: left;
                }
                th { background: var(--table-header-bg); font-weight: 600; }
                tr:nth-child(even) { background: var(--table-row-alt); }
                hr { border: none; border-top: 1px solid var(--border); margin: 24px 0; }
                .note, .important, .warning, .tip, .caution {
                    border-left: 4px solid var(--link);
                    background: var(--code-bg);
                    border-radius: 0 6px 6px 0;
                    padding: 12px 16px;
                    margin-bottom: 16px;
                }
            </style>
        </head>
        <body>
            {{bodyHtml}}
        </body>
        </html>
        """;
}
