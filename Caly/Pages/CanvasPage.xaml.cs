// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using System;
using Microsoft.UI;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Microsoft.UI.Xaml.Controls;

namespace WinUICommunityGallery.Pages;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
///


public enum InkStrokeState
{
    UNSELECTED,
    SELECTED, 
    DELETED 
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

    private PointerPoint _prevPoint;


    public CanvasPage()
    {
        InitializeComponent();
        // DrawCanvas.CreateResources += DrawCanvas_CreateResources ;
        DrawCanvas.PointerPressed += DrawCanvas_PointerPressed;
        DrawCanvas.PointerMoved += DrawCanvas_PointerMoved;
        DrawCanvas.PointerReleased += DrawCanvas_PointerReleased;
        DrawCanvas.PointerExited += DrawCanvas_PointerExited;
        DrawCanvas.PointerWheelChanged += DrawCanvas_PointerWheelChanged;
        // DrawCanvas.RegionsInvalidated += DrawCanvas_RegionsInvalidated;
        Unloaded += CanvasPage_Unloaded;
        //disable default pen handler
        ScrollViewerContainer.PointerPressed+=ScrollPointer_Pressed;

    }

    private void ScrollPointer_Pressed(object sender, PointerRoutedEventArgs e)
    {
        if (e.Pointer.PointerDeviceType == PointerDeviceType.Pen)
        {
            ScrollViewerContainer.Content.ManipulationMode &= ~ManipulationModes.System;
        }
    }



    private void CanvasPage_Unloaded(object sender, RoutedEventArgs e)
    {
        // DrawCanvas.RemoveFromVisualTree();
        // DrawCanvas = null;
    }


    private void DrawCanvas_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
    {
     
    }

    private void DrawCanvas_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        _isDrawing = false;
    }

    private void DrawCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        _isDrawing = false;
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
        if (CheckPositionDistance(point, _prevPoint))
        {
            var line= new Line
            {
                X1 = _prevPoint.Position.X,
                Y1 = _prevPoint.Position.Y,
                X2 = point.Position.X,
                Y2 = point.Position.Y,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = _prevPoint.Properties.Pressure * 2
            };
            DrawCanvas.Children.Add(line);
            _prevPoint = point;

        }


    }

    private void DrawCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        _isDrawing = true;
        //new line
        // _currentLine = new InkStrokeLine
        // {
        //     points = []
        // };
        _prevPoint= e.GetCurrentPoint(DrawCanvas);
        // _currentLine.points.Add(_prevPoint);
    }
}
