

namespace Wordle2023;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();

	}

	private async void LoginButton_Clicked(object sender, EventArgs e)
	{
       await Shell.Current.GoToAsync("//MainPage", true);
		
		//store the username value
		UserData.EnteredText = UsernameEntry.Text;


    }

	public static class UserData
	{
        public static string EnteredText { get; set; }
    }
}