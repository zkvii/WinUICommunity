﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using DemoApp.Pages;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.AppNotifications;

using Windows.Storage;

using WinUICommunity;
using WinUICommunity.DemoApp.AppNotification;
using WinUICommunity.DemoApp.Pages;

namespace DemoApp;

public partial class App : Application
{
    public static Window currentWindow = Window.Current;

    public NavigationManager NavigationManager { get; set; }
    public ThemeManager ThemeManager { get; set; }
    private NotificationManager notificationManager;
    public new static App Current => (App)Application.Current;

    public App()
    {
        this.InitializeComponent();
        if (!ApplicationHelper.IsPackaged)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            var c_notificationHandlers = new Dictionary<int, Action<AppNotificationActivatedEventArgs>>();
            c_notificationHandlers.Add(ToastWithAvatar.Instance.ScenarioId, ToastWithAvatar.Instance.NotificationReceived);
            c_notificationHandlers.Add(ToastWithTextBox.Instance.ScenarioId, ToastWithTextBox.Instance.NotificationReceived);
            c_notificationHandlers.Add(ToastWithPayload.Instance.ScenarioId, ToastWithPayload.Instance.NotificationReceived);
            notificationManager = new NotificationManager(c_notificationHandlers);
        }
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        currentWindow = new Window();

        if (currentWindow.Content is not Frame rootFrame)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            currentWindow.Content = rootFrame = new Frame();
        }

        rootFrame.Navigate(typeof(MainPage), args.Arguments);

        ThemeManager = new ThemeManager(currentWindow, new ThemeOptions
        {
            BackdropType = BackdropType.MicaAlt,
            ElementTheme = ElementTheme.Default,
            TitleBarCustomization = new TitleBarCustomization
            {
                TitleBarType = TitleBarType.AppWindow
            }
        });

        if (!ApplicationHelper.IsPackaged)
        {
            notificationManager.Init(notificationManager, OnNotificationInvoked);
        }
        await InitializeLocalizer("fa-IR", "en-US");

        // Ensure the current window is active
        currentWindow.Activate();
    }

    private void OnNotificationInvoked(string message)
    {
        AppNotificationPage.Instance.NotificationInvoked(message);
    }

    void OnProcessExit(object sender, EventArgs e)
    {
        notificationManager.Unregister();
    }

    private static string StringsFolderPath { get; set; } = string.Empty;

    private async Task InitializeLocalizer(params string[] languages)
    {
        // Initialize a "Strings" folder in the "LocalFolder" for the packaged app.
        if (ApplicationHelper.IsPackaged)
        {
            // Create string resources file from app resources if doesn't exists.
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder stringsFolder = await localFolder.CreateFolderAsync(
              "Strings",
               CreationCollisionOption.OpenIfExists);
            string resourceFileName = "Resources.resw";
            foreach (var item in languages)
            {
                await LocalizerBuilder.CreateStringResourceFileIfNotExists(stringsFolder, item, resourceFileName);
            }

            StringsFolderPath = stringsFolder.Path;
        }
        else
        {
            // Initialize a "Strings" folder in the executables folder.
            StringsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Strings");
            //StorageFolder localFolder = await StorageFolder.GetFolderFromPathAsync(Directory.GetCurrentDirectory());
            var stringsFolder = await StorageFolder.GetFolderFromPathAsync(StringsFolderPath);
        }


        ILocalizer localizer = await new LocalizerBuilder()
            .AddStringResourcesFolderForLanguageDictionaries(StringsFolderPath)
            .SetOptions(options =>
            {
                options.DefaultLanguage = "en-US";
                options.UseUidWhenLocalizedStringNotFound = true;
            })
            .Build();
    }
}
