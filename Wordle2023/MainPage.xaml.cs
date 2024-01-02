using Wordle2023.GameView;

namespace Wordle2023
{
    public partial class MainPage : ContentPage
    {

        public MainPage(GameViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }

}
