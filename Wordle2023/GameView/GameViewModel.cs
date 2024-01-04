using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
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

    private ObservableCollection<Color> keyboard1Colors;
    public ObservableCollection<Color> Keyboard1Colors
    {
        get { return keyboard1Colors; }
        set { SetProperty(ref keyboard1Colors, value); }
    }

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

        // Initialize colors for keyboard1
        Keyboard1Colors = new ObservableCollection<Color>(keyboard1.Select(_ => Color.FromRgb(0,0,0)));
    }

    public void Enter()
    {
        if(columnsIndex != 5)
            return;


        var answer = Rows[rowsIndex].Validate(correctWord);

        if (answer)
        {
            App.Current.MainPage.DisplayAlert("You Win", "You Win", "OK");
            return;  
        }

        if(rowsIndex == 5)
        {
            App.Current.MainPage.DisplayAlert("Game Over", "Out of Turns", "OK");
        }

        else
        {
            rowsIndex++;
            columnsIndex = 0;
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
            if(columnsIndex == 0)            
                return;
            columnsIndex--;
                Rows[rowsIndex].Letters[columnsIndex].Input = ' ';

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
