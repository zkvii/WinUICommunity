// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using System;
using System.Numerics;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.UI;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Input.Inking;
using Microsoft.Graphics.Canvas.Text;
using Windows.Foundation.Metadata;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.UI.Xaml.Controls;

namespace WinUICommunityGallery.Pages;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
///
public enum InkStrokeState
{
    UNDRAWED = 0,
    DRAWED = 1,
    SELECTED = 2,
    DELETED = 3
}

public class InkStrokeLine
{
    public List<PointerPoint> points;
    public InkPoint leftToPPoint;
    public InkPoint rightBottomPoint;
    public InkStrokeState state;
}

public sealed partial class CanvasPage
{
    private bool _isDrawing;

    private readonly List<InkStrokeLine> _lines = new();

    private InkStrokeLine _currentLine = new();


    public CanvasPage()
    {
        InitializeComponent();
        DrawCanvas.CreateResources += DrawCanvas_CreateResources;
        DrawCanvas.PointerPressed += DrawCanvas_PointerPressed;
        DrawCanvas.PointerMoved += DrawCanvas_PointerMoved;
        DrawCanvas.PointerReleased += DrawCanvas_PointerReleased;
        DrawCanvas.PointerExited += DrawCanvas_PointerExited;
        DrawCanvas.PointerWheelChanged += DrawCanvas_PointerWheelChanged;
        DrawCanvas.RegionsInvalidated += DrawCanvas_RegionsInvalidated;
        Unloaded += CanvasPage_Unloaded;
    }

    private void DrawCanvas_CreateResources(CanvasVirtualControl sender, CanvasCreateResourcesEventArgs args)
    {
    }

    private void DrawCanvas_RegionsInvalidated(CanvasVirtualControl sender, CanvasRegionsInvalidatedEventArgs args)
    {
        foreach (var region in args.InvalidatedRegions)
        {
            foreach (var line in _lines)
            {
                for (var i = 0; i < line.points.Count - 1; ++i)
                {
                    using var ds = sender.CreateDrawingSession(region);
                    ds.DrawLine(line.points[i].Position.ToVector2(),
                        line.points[i + 1].Position.ToVector2(),
                        Colors.Black, line.points[i].Properties.Pressure * 2);
                }
            }
        }
    }


    private void CanvasPage_Unloaded(object sender, RoutedEventArgs e)
    {
        DrawCanvas.RemoveFromVisualTree();
        DrawCanvas = null;
    }


    private void DrawCanvas_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
    {
        var ctrl = InputKeyboardSource.GetKeyStateForCurrentThread(Windows.System.VirtualKey.Control);
    }

    private void DrawCanvas_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        _isDrawing = false;
    }

    private void DrawCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        _isDrawing = false;
        _lines.Add(_currentLine);
    }

    private bool CheckPositionDistance(PointerPoint currentPoint, PointerPoint prevPoint)
    {
        return Math.Abs(prevPoint.Position.X - currentPoint.Position.X) +
            Math.Abs(prevPoint.Position.Y - currentPoint.Position.Y) > 0.2;
    }

    private void DrawCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        if (!_isDrawing)
        {
            return;
        }

        var point = e.GetCurrentPoint(DrawCanvas);

        _currentLine.points.Add(point);
        DrawCanvas.Invalidate();
    }

    private void DrawCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        _isDrawing = true;
        //new line
        _currentLine = new InkStrokeLine
        {
            points = []
        };
        var point = e.GetCurrentPoint(DrawCanvas);
        _currentLine.points.Add(point);
        _currentLine.state = InkStrokeState.UNDRAWED;
    }
}
