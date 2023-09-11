namespace MauiApp1.Views;

public partial class Page1 : BaseContentPage, IContentPage
{
    public static string Route => "page1";
    static string IContentPage.PageRoute => Route;

    public Page1()
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
        await Shell.Current.GoToAsync(Page2.Route);
    }
}