﻿using Microsoft.UI.Xaml.Controls;

namespace WinUICommunityGallery.Pages;
public sealed partial class AutoScrollViewPage : Page
{
    public AutoScrollViewPage()
    {
        this.InitializeComponent();
    }

    private void AutoScrollHoverEffectView_PointerCanceled(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        AutoScrollHoverEffectView.IsPlaying = false;
    }

    private void AutoScrollHoverEffectView_PointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        AutoScrollHoverEffectView.IsPlaying = true;
    }

    private void AutoScrollHoverEffectView_PointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        AutoScrollHoverEffectView.IsPlaying = false;
    }
}
