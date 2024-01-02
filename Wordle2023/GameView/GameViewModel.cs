using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wordle2023.Model;

namespace Wordle2023.GameView;

public partial class GameViewModel : ObservableObject
{

    //0 - 5
    int rowsIndex;

    //0 - 4
    int columnsIndex;

    char[] correctWord;

    [ObservableProperty]
    private WordRows[] rows;

    public GameViewModel()
    {
       rows = new WordRows[6]
        {
            new WordRows(),
            new WordRows(),
            new WordRows(),
            new WordRows(),
            new WordRows(),
            new WordRows()

        };

        correctWord = "DONNY".ToCharArray();
       
    }

    [RelayCommand]
    public void Enter()
    {
        if(columnsIndex != 4)
        {
            return;
        }
       

        var valid = true;

        if (valid)
        {
            if (rowsIndex == 5)
            {
                // Game over
            }
            else
            {
                rowsIndex++;
                columnsIndex = 0;
            }
        }
    }

    [RelayCommand]
    public void EnterLetter(char letter)
    {

        if(columnsIndex == 5)
        {
            return;
        }
       
    }

}
