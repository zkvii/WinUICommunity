﻿
namespace WinUICommunity;
public interface IThemeService
{
    void Initialize(Window window, bool useAutoSave = true, string filename = null);
    void ConfigBackdrop(BackdropType backdropType = BackdropType.Mica, bool force = false);
    void ConfigBackdropTintColor(Color color, bool force = false);
    void ConfigBackdropFallBackColor(Color color, bool force = false);
    void ConfigBackdropTintOpacity(float opacity, bool force = false);
    void ConfigBackdropLuminosityOpacity(float opacity, bool force = false);
    void ConfigElementTheme(ElementTheme elementTheme = ElementTheme.Default, bool force = false);
    void ConfigTitleBar(TitleBarCustomization titleBarCustomization);
    void ConfigBackdropFallBackColorForWindow10(Brush? brush);

    delegate void ActualThemeChangedEventHandler(FrameworkElement sender, object args);
    event ActualThemeChangedEventHandler ActualThemeChanged;

    Window Window { get; set; }
    SystemBackdrop CurrentSystemBackdrop { get; set; }
    BackdropType CurrentBackdropType { get; set; }
    SystemBackdrop GetSystemBackdrop(BackdropType backdropType);
    SystemBackdrop GetSystemBackdrop();
    BackdropType GetBackdropType(SystemBackdrop systemBackdrop);
    BackdropType GetBackdropType();
    ElementTheme GetElementTheme();

    void SetBackdropType(BackdropType backdropType);
    void SetBackdropLuminosityOpacity(float opacity);
    void SetBackdropTintOpacity(float opacity);
    void SetBackdropFallBackColor(Color color);
    void SetBackdropTintColor(Color color);
    bool IsDarkTheme();
    void UpdateSystemCaptionButtonForAppWindow(Window window);
    void ResetCaptionButtonColors(Window window);
    void UpdateSystemCaptionButton(Window window);
    void SetElementTheme(ElementTheme elementTheme);
    void SetElementThemeWithoutSave(ElementTheme elementTheme);
    void OnThemeComboBoxSelectionChanged(object sender);
    void SetThemeComboBoxDefaultItem(ComboBox themeComboBox);
    void OnBackdropComboBoxSelectionChanged(object sender);
    void SetBackdropComboBoxDefaultItem(ComboBox backdropComboBox);
    void OnThemeRadioButtonChecked(object sender);
    void SetThemeRadioButtonDefaultItem(Panel ThemePanel);
    void OnBackdropRadioButtonChecked(object sender);
    void SetBackdropRadioButtonDefaultItem(Panel BackdropPanel);
    ElementTheme GetActualTheme();
}
