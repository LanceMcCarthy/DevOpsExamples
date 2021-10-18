using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.Common;

namespace SDKBrowserMaui.Examples.PathControl.FeaturesCategory.PathGeometryExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PathGeometry : RadContentView
    {
        public PathGeometry()
        {
            InitializeComponent();
            RadPathFigure customLine = new RadPathFigure();
            customLine.StartPoint = new Point(0.8, 0.1);
            customLine.Segments.Add(new RadLineSegment(new Point(0.1, 0.8)));

            customLine.Segments.Add(new RadArcSegment() { Center = new Point(0.125, 0.825), StartAngle = 135, SweepAngle = 180, Size = new Size(0.070710678, 0.070710678) });
            customLine.Segments.Add(new RadLineSegment(new Point(0.85, 0.15)));
            customLine.Segments.Add(new RadArcSegment() { Center = new Point(0.825, 0.125), StartAngle = 315, SweepAngle = 180, Size = new Size(0.070710678, 0.070710678) });

            RadPathGeometry geometry = new RadPathGeometry();
            geometry.Figures.Add(customLine);
            customLinePath.Geometry = geometry;
        }
    }
}