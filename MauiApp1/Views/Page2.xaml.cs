namespace MauiApp1.Views;

public partial class Page2 : BaseContentPage, IContentPage
{
    public static string Route => "page2";
    static string IContentPage.PageRoute => Route;

    public Page2()
	{
		InitializeComponent();
	}

    async void Logoff_Clicked(object sender, EventArgs e)
    {
        if (Shell.Current is not AppShell shell) return;

        await shell.LogoffAsync();
    }

    async void Next_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(Page3.Route);
    }
}