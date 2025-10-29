#pragma warning disable JMA001
using SkiaSharp;
using System.Diagnostics;
using System.Globalization;
using Telerik.Maui.Controls.SignaturePad;

namespace MauiDemo.Views;

public partial class SignaturePadPage : ContentPage
{
	public SignaturePadPage()
	{
		InitializeComponent();
	}

    private async void LoadButton_OnClicked(object sender, EventArgs e)
    {
        try
        {
            await using var stream = await FileSystem.OpenAppPackageFileAsync("john_hancock.png");

            var memStream = new MemoryStream();
            await stream.CopyToAsync(memStream);
            memStream.Position = 0;

            ProcessImage(memStream.ToArray());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    private async void SaveButton_OnClicked(object sender, EventArgs e)
    {
        try
        {
            using var stream = new MemoryStream();

            await SigPad1.SaveImageAsync(stream, new SaveImageSettings
            {
                ImageFormat = Telerik.Maui.Controls.SignaturePad.ImageFormat.Png,
                BackgroundColor = Colors.AliceBlue,
                StrokeColor = Colors.DarkBlue,
                StrokeThickness = 2
            });

            ProcessImage(stream.ToArray());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    private void ClearButton_OnClicked(object sender, EventArgs e)
    {
        SigPad1.ClearCommand.Execute(null);
    }

    private void ProcessImage(byte[] imageBytes)
    {
        // Preview image preview
        SignatureImage.Source = ImageSource.FromStream(()=> new MemoryStream(imageBytes));

        // WORKAROUND TAKEAWAY! Use the PNG image, and scan it to create the vector string data (SVG or Custom)
        OutputLabel.Text = GetVectorFromSignatureImage(imageBytes);
    }

    public static string GetVectorFromSignatureImage(byte[] imageBytes, VectorStringFormat formatType = VectorStringFormat.Custom)
    {
        // ----------------------------------------------------------- //
        //                   >>> PHASE 1 <<<                           //
        //    Prepare stream input and generate working bitmaps        //
        // ----------------------------------------------------------- //

        using var bitmap = SKBitmap.Decode(imageBytes);

        var grayscaleBitmap = new SKBitmap(bitmap.Width, bitmap.Height);
        var binaryBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

        Debug.WriteLine($"VECTOR: bitmap decoded - {bitmap.Width}x{bitmap.Height}");

        for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
        {
            var color = bitmap.GetPixel(x, y);
            var gray = (byte)(0.3 * color.Red + 0.59 * color.Green + 0.11 * color.Blue);
            grayscaleBitmap.SetPixel(x, y, new SKColor(gray, gray, gray));
        }

        Debug.WriteLine($"VECTOR: grayscaleBitmap created");

        // Byte value threshold to force a black or white pixel value (for better point detection):
        const int threshold = 128;

        for (var y = 0; y < grayscaleBitmap.Height; y++)
        for (var x = 0; x < grayscaleBitmap.Width; x++)
        {
            var color = grayscaleBitmap.GetPixel(x, y);
            var value = color.Red < threshold ? SKColors.Black : SKColors.White;
            binaryBitmap.SetPixel(x, y, value);
        }

        Debug.WriteLine("VECTOR: binaryBitmap created");


        // ----------------------------------------------------------- //
        //                   >>> PHASE 2 <<<                           //
        //          Scan bitmaps and create SKPoint lists              //
        // ----------------------------------------------------------- //

        // ** OPTION 1 ** -
        // More advanced option that scans neighbors and creates groups of points into complete strokes
        // Group strokes based on if neighboring pixels within a small radius are also black, we group the points together into a stroke
        var pxScanned = new bool[binaryBitmap.Width, binaryBitmap.Height];
        var groupedStrokes = new List<List<SKPoint>>();

        int[] dx = [-1, 0, 1, 0, -1, -1, 1, 1];
        int[] dy = [0, -1, 0, 1, -1, 1, -1, 1];

        for (var y = 0; y < binaryBitmap.Height; y++)
        for (var x = 0; x < binaryBitmap.Width; x++)
        {
            if (pxScanned[x, y] || binaryBitmap.GetPixel(x, y) != SKColors.Black)
                continue;

            pxScanned[x, y] = true;

            var queue = new Queue<SKPoint>();
            queue.Enqueue(new SKPoint(x, y));

            var stroke = new List<SKPoint>();

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                stroke.Add(point);

                for (var i = 0; i < dx.Length; i++)
                {
                    var nx = (int)point.X + dx[i];
                    var ny = (int)point.Y + dy[i];

                    if (nx >= 0
                        && ny >= 0
                        && nx < binaryBitmap.Width
                        && ny < binaryBitmap.Height
                        && !pxScanned[nx, ny]
                        && binaryBitmap.GetPixel(nx, ny) == SKColors.Black)
                    {
                        pxScanned[nx, ny] = true;

                        queue.Enqueue(new SKPoint(nx, ny));
                    }
                }
            }

            if (stroke.Count > 0)
                groupedStrokes.Add(stroke);
        }

        Debug.WriteLine($"VECTOR: binaryBitmap strokes scanned, {groupedStrokes.Count} groupedStrokes");


        // ** OPTION 2 ** a simple ungroups list of points
        //var strokePoints = new List<SKPoint>();
        //for (var y = 0; y < binaryBitmap.Height; y++)
        //for (var x = 0; x < binaryBitmap.Width; x++)
        //{
        //    if (binaryBitmap.GetPixel(x, y) == SKColors.Black)
        //    {
        //        strokePoints.Add(new SKPoint(x, y));
        //    }
        //}


        // ----------------------------------------------------------- //
        //                   >>> PHASE 3 <<<                           //
        //               Create desired vector string data             //
        // ----------------------------------------------------------- //

        var sb = new System.Text.StringBuilder();
        var ic = CultureInfo.InvariantCulture;
        var fm = "N1";

        switch (formatType)
        {
            // ***** Custom data output format ***** //
            // "1,2;3,4;5,6;7,8/10,11;12,13;14,15/21,22;23,24;25,26"
            case VectorStringFormat.Custom:
            {
                for (var i = 0; i < groupedStrokes.Count; i++)
                {
                    for (var j = 0; j < groupedStrokes[i].Count; j++)
                    {
                        sb.Append(groupedStrokes[i][j].X.ToString(fm, ic));
                        sb.Append(",");
                        sb.Append(groupedStrokes[i][j].Y.ToString(fm, ic));

                        // After each point, add a semicolon (except for the last one!)
                        if (j < groupedStrokes.Count - 1) 
                            sb.Append(";");

                    }

                    // After each stroke, add a slash (except for the last one!)
                    if (i < groupedStrokes.Count - 1) 
                        sb.Append("/");
                }

                break;
            }
            // ***** SVG-like data output format ***** //
            // "M x y L x y L x y ..."
            case VectorStringFormat.Svg:
            {
                for (var gs = 0; gs < groupedStrokes.Count - 1; gs++)
                {
                    if (gs == 0) sb.Append("M ");

                    for (var p = 0; p < groupedStrokes[gs].Count - 1; p++)
                    {
                        sb.Append(" L ");
                        sb.Append(groupedStrokes[gs][p].X.ToString(fm, ic));
                        sb.Append(" ");
                        sb.Append(groupedStrokes[gs][p].Y.ToString(fm, ic));
                    }
                }

                break;
            }
        }

        var response = sb.ToString();

        Debug.WriteLine($"VECTOR: {formatType} string created => {response}");

        return response;
    }
}

public enum VectorStringFormat
{
    /// <summary>
    /// SVG-like path string is requested: "M x y L x y L x y ..."
    /// </summary>
    Svg,
    /// <summary>
    /// custom data format "1,2;3,4;5,6;7,8/10,11;12,13;14,15/21,22;23,24;25,26"
    /// </summary>
    Custom
}