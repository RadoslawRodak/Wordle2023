using Wordle2023.GameView;

namespace Wordle2023
{

    public partial class MainPage : ContentPage
    {
        public MainPage(GameViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            var frame = new Frame();

           
        }

        private async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }

        
    }

   

   
}
