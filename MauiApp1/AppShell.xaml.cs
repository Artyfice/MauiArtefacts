using MauiApp1.Debugging;
using MauiApp1.Views;
using System.Reflection;
using System.Windows.Input;

namespace MauiApp1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = this;

        AddShellItem<LoginPage>();
        AddFlyoutItem<Page1>("Page 1");
        AddMenuItem("Logoff", LogoffCommand);
        Routing.RegisterRoute("page2", typeof(Page2));
        Routing.RegisterRoute("page3", typeof(Page3));
    }

    void AddShellItem<TPage>() where TPage : IContentPage
    {
        var type = typeof(TPage);
        var route = (string)type.GetProperty($"{typeof(IContentPage).FullName}.{nameof(IContentPage.PageRoute)}", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

        var shellItem = new ShellItem
        {
            Route = route,
            FlyoutItemIsVisible = false
        };

        shellItem.Items.Add(new ShellContent
        {
            ContentTemplate = new DataTemplate(type)
        });

        Items.Add(shellItem);
    }

    void AddFlyoutItem<TPage>(string title) where TPage : IContentPage
    {
        var type = typeof(TPage);
        var route = (string)type.GetProperty($"{typeof(IContentPage).FullName}.{nameof(IContentPage.PageRoute)}", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

        var flyoutItem = new FlyoutItem
        {
            Route = route,
            Title = title
        };

        flyoutItem.Items.Add(new ShellContent
        {
            ContentTemplate = new DataTemplate(type)
        });

        Items.Add(flyoutItem);
    }

    void AddMenuItem(string title, ICommand command)
    {
        Items.Add(new MenuItem
        {
            Command = command,
            Text = title
        });
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        DebuggingOutput.Log(GetType(), $"{args.Current?.Location.OriginalString ?? "//"} -> {args.Target.Location.OriginalString} ({args.Source})");
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);

        DebuggingOutput.Log(GetType(), args.Current.Location.OriginalString);
    }

    ICommand _logoffCommand;
    ICommand LogoffCommand => _logoffCommand ??= new Command(async () => await LogoffAsync()); 

    public async Task LogoffAsync()
    {
        await Dispatcher.DispatchAsync(async () => await GoToAsync($"//{LoginPage.Route}"));
    }
}