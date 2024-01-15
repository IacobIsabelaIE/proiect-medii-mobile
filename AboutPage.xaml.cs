namespace ProiectMobile;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    async void OnContactButtonClicked(object sender, EventArgs e)
    {
        // Navigate to MainPage
        var mainPage = new MainPage();

        await Navigation.PushAsync(mainPage);
    }

}