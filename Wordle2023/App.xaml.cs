namespace Wordle2023
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //set main page as instance of AppShell
            MainPage = new AppShell();
        }
    }
}
