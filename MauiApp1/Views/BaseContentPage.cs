using MauiApp1.Debugging;

namespace MauiApp1.Views;

public abstract partial class BaseContentPage : ContentPage
{
    public BaseContentPage()
    {
        Appearing += OnAppearing;
        NavigatingFrom += OnNavigatingFrom;
        NavigatedTo += OnNavigatedTo;
        NavigatedFrom += OnNavigatedFrom;
        Disappearing += OnDisappearing;
    }

    ~BaseContentPage()
    {
        Appearing -= OnAppearing;
        NavigatingFrom -= OnNavigatingFrom;
        NavigatedTo -= OnNavigatedTo;
        NavigatedFrom -= OnNavigatedFrom;
        Disappearing -= OnDisappearing;
    }

    void OnAppearing(object sender, EventArgs args) => DebuggingOutput.Log(GetType());
    void OnNavigatingFrom(object sender, NavigatingFromEventArgs args) => DebuggingOutput.Log(GetType());
    void OnNavigatedTo(object sender, NavigatedToEventArgs args) => DebuggingOutput.Log(GetType());
    void OnNavigatedFrom(object sender, NavigatedFromEventArgs args) => DebuggingOutput.Log(GetType());
    void OnDisappearing(object sender, EventArgs args) => DebuggingOutput.Log(GetType());
}