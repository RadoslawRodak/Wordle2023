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

    public char[] keyboard1 { get; }
    public char[] keyboard2 { get; }
    public char[] keyboard3 { get; }

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
        keyboard1 = "QWERTYUIOP".ToCharArray();
        keyboard2 = "ASDFGHJKL".ToCharArray();
        keyboard3 = "<ZXCVBNM>".ToCharArray();
        
       
    }

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
        if(letter == '>')
        {
            Enter();
            return;
        }

        if(letter == '<')
        {
            return;
        }

        if(columnsIndex == 5)
        {
            return;
        }

        Rows[rowsIndex].Letters[columnsIndex].Input = letter;
        columnsIndex++;
    }

}
