namespace MauiApp1.Views;

public partial class Page3 : BaseContentPage, IContentPage
{
    public static string Route => "page3";
    static string IContentPage.PageRoute => Route;

    public Page3()
	{
		InitializeComponent();
	}

    async void Logoff_Clicked(object sender, EventArgs e)
    {
        if (Shell.Current is not AppShell shell) return;

        await shell.LogoffAsync();
    }
}