namespace MauiApp1.Views;

public partial class LoginPage : BaseContentPage, IContentPage
{
	public static string Route => "login";
	static string IContentPage.PageRoute => Route;

    public LoginPage()
	{
		InitializeComponent();
	}

    async void Logon_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{Page1.Route}");
    }
}