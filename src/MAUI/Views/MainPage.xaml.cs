using System.Diagnostics;
using MauiDemo.Interfaces;
using MauiDemo.ViewModels;
using Telerik.Maui.Data;

#if ANDROID
using Android.Graphics;
#elif IOS || MACCATALYST
using Foundation;
using UIKit;
#elif WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
#endif

namespace MauiDemo.Views;

public partial class MainPage : ContentPage, IDataGridView
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;

        // Identify this view for the IoC reference
        vm.DataGridView = this;
    }

    public IDataViewCollection GetDataView()
    {
        return EmployeesGrid.GetDataView();
    }


private async void OnRenderPngClicked(object? sender, EventArgs e)
{
    try
    {
        // Generate png image
        var imageBytes = await CaptureViewAsync(EmployeesGrid);

        // Option 1 - Save image as a png file
        var downloadsFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        var imagePath = System.IO.Path.Combine(downloadsFolder, "MyChart.png");
        await File.WriteAllBytesAsync(imagePath, imageBytes);


        // Option 2 - Export as PDF
        var pdfPath = System.IO.Path.Combine(downloadsFolder, "MyChart.pdf");
        await GeneratePdf(imagePath, pdfPath);
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex);
    }
}

private async Task GeneratePdf(string imagePath, string pdfPath)
{
    // Create a new, blank FixedDocument and add a page to it
    var fixedDocument = new Telerik.Windows.Documents.Fixed.Model.RadFixedDocument();
    var fixedPage = fixedDocument.Pages.AddPage();

    // Create an Image object, set its source to the captured image, and add it to the page
    var img = new Telerik.Windows.Documents.Fixed.Model.Objects.Image();

    await using (FileStream fileStream = new FileStream(imagePath, FileMode.Open))
    {
        img.ImageSource = new Telerik.Windows.Documents.Fixed.Model.Resources.ImageSource(fileStream);

        // Set image properties
        img.AlphaConstant = 0.5;
        img.Width = 200;
        img.Height = 200;

        // Set image location in the document
        var simplePosition = new Telerik.Windows.Documents.Fixed.Model.Data.SimplePosition();
        simplePosition.Translate(200, 300);
        img.Position = simplePosition;

        // Finally add the image to the page
        fixedPage.Content.Add(img);
    }

    // Finally, use the PdfFormatProvider and export the FixedDocument to a PDF file
    var pdfProvider = new Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.PdfFormatProvider();

    await using (var output = File.OpenWrite(pdfPath))
    {
        pdfProvider.Export(fixedDocument, output, TimeSpan.FromSeconds(10));
    }
}


    public async Task<byte[]> CaptureViewAsync(Microsoft.Maui.Controls.View view)
    {

#if ANDROID
        var nativeView = view.Handler?.PlatformView as Android.Views.View
            ?? throw new InvalidOperationException("View must be loaded before capture.");

        var width = nativeView.Width > 0 ? nativeView.Width : (int)(view.Width * DeviceDisplay.MainDisplayInfo.Density);
        var height = nativeView.Height > 0 ? nativeView.Height : (int)(view.Height * DeviceDisplay.MainDisplayInfo.Density);

        nativeView.Measure(
            Android.Views.View.MeasureSpec.MakeMeasureSpec(width, Android.Views.MeasureSpecMode.Exactly),
            Android.Views.View.MeasureSpec.MakeMeasureSpec(height, Android.Views.MeasureSpecMode.Exactly));
        nativeView.Layout(0, 0, width, height);

        using var bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
        using var canvas = new Canvas(bitmap);
        nativeView.Draw(canvas);

        using var ms = new MemoryStream();
        bitmap.Compress(Bitmap.CompressFormat.Png, 100, ms);
        return ms.ToArray();

#elif IOS || MACCATALYST
        var nativeView = view.Handler?.PlatformView as UIView
            ?? throw new InvalidOperationException("View must be loaded before capture.");

        nativeView.SetNeedsLayout();
        nativeView.LayoutIfNeeded();

        UIGraphics.BeginImageContextWithOptions(nativeView.Bounds.Size, false, UIScreen.MainScreen.Scale);
        try
        {
            nativeView.DrawViewHierarchy(nativeView.Bounds, true);

            using var image = UIGraphics.GetImageFromCurrentImageContext();
            using var imageData = image?.AsPNG();

            return imageData?.ToArray() ?? Array.Empty<byte>();
        }
        finally
        {
            UIGraphics.EndImageContext();
        }

#elif WINDOWS
        var nativeView = view.Handler?.PlatformView as FrameworkElement
            ?? throw new InvalidOperationException("View must be loaded before capture.");

        var renderTargetBitmap = new RenderTargetBitmap();
        await renderTargetBitmap.RenderAsync(nativeView);

        var pixels = (await renderTargetBitmap.GetPixelsAsync()).ToArray();

        using var stream = new InMemoryRandomAccessStream();
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
        encoder.SetPixelData(
            BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Premultiplied,
            (uint)renderTargetBitmap.PixelWidth,
            (uint)renderTargetBitmap.PixelHeight,
            96,
            96,
            pixels);

        await encoder.FlushAsync();

        stream.Seek(0);
        using var reader = new DataReader(stream.GetInputStreamAt(0));
        await reader.LoadAsync((uint)stream.Size);
        var bytes = new byte[stream.Size];
        reader.ReadBytes(bytes);

        return bytes;
#else
        throw new PlatformNotSupportedException();
#endif
    }
}