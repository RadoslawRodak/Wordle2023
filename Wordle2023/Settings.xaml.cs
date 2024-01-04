using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Graphics.Text;
using Wordle2023.Model;

namespace Wordle2023;

public partial class Settings : ContentPage
{
   
    public Settings()
	{
		
		InitializeComponent();
    }
	
	private void LightMode_Clicked (object sender, EventArgs e)
	{
        
            // Change the color resources to light mode colors
            Application.Current.Resources["PrimaryColor"] = Color.FromRgb(255, 255, 255);
            Application.Current.Resources["SecondaryColor"] = Color.FromRgb(100, 100, 100);
            Application.Current.Resources["ThirdColor"] = Color.FromRgb(0, 0, 0);


        
    }

	private void DarkMode_Clicked(object sender, EventArgs e)
	{
        BackgroundColor = Color.FromRgb(15, 15, 15);
        Application.Current.Resources["PrimaryColor"] = Color.FromRgb(15, 15, 15);


    }
}