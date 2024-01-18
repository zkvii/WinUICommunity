﻿using Microsoft.UI.Composition;
using Microsoft.UI.Composition.SystemBackdrops;

namespace WinUICommunity;
public class AcrylicBackdrop : SystemBackdrop
{
    public DesktopAcrylicController acrylicController = new DesktopAcrylicController();

    private DesktopAcrylicKind kind;
    public DesktopAcrylicKind Kind
    {
        get { return kind; }
        set
        {
            kind = value;
            if (acrylicController != null)
            {
                acrylicController.Kind = value;
            }
        }
    }


    private Color tintColor;
    public Color TintColor
    {
        get { return tintColor; }
        set
        {
            tintColor = value;
            if (acrylicController != null)
            {
                acrylicController.TintColor = value;
            }
        }
    }


    private Color fallbackColor;
    public Color FallbackColor
    {
        get { return fallbackColor; }
        set
        {
            fallbackColor = value;
            if (acrylicController != null)
            {
                acrylicController.FallbackColor = value;
            }
        }
    }


    private float tintOpacity;
    public float TintOpacity
    {
        get { return tintOpacity; }
        set
        {
            tintOpacity = value;
            if (acrylicController != null)
            {
                acrylicController.TintOpacity = value;
            }
        }
    }


    private float luminosityOpacity;
    public float LuminosityOpacity
    {
        get { return luminosityOpacity; }
        set
        {
            luminosityOpacity = value;
            if (acrylicController != null)
            {
                acrylicController.LuminosityOpacity = value;
            }
        }
    }
    protected override void OnTargetConnected(ICompositionSupportsSystemBackdrop connectedTarget, XamlRoot xamlRoot)
    {
        base.OnTargetConnected(connectedTarget, xamlRoot);

        // Set configuration.
        SystemBackdropConfiguration defaultConfig = GetDefaultSystemBackdropConfiguration(connectedTarget, xamlRoot);
        acrylicController.SetSystemBackdropConfiguration(defaultConfig);

        // Add target.
        acrylicController.AddSystemBackdropTarget(connectedTarget);
    }
    protected override void OnTargetDisconnected(ICompositionSupportsSystemBackdrop disconnectedTarget)
    {
        base.OnTargetDisconnected(disconnectedTarget);
        acrylicController.RemoveSystemBackdropTarget(disconnectedTarget);
        acrylicController = null;
    }
}
