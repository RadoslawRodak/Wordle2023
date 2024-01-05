using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Wordle2023.Model;

namespace Wordle2023.GameView;

public partial class GameViewModel : ObservableObject
{
    ListOfWords list;

    //0 - 5
    int rowsIndex;

    //0 - 4
    int columnsIndex;
 


    public char[] keyboard1 { get; }
    public char[] keyboard2 { get; }
    public char[] keyboard3 { get; }

    [ObservableProperty]
    private WordRows[] rows;

    public GameViewModel()
    {
        list = new ListOfWords();
        rows = new WordRows[6]
        {
            new WordRows(),
            new WordRows(),
            new WordRows(),
            new WordRows(),
            new WordRows(),
            new WordRows()
            
        };

       
         keyboard1 = "QWERTYUIOP".ToCharArray();
         keyboard2 = "ASDFGHJKL".ToCharArray();
         keyboard3 = "<ZXCVBNM>".ToCharArray();
       

        InitializeAsync();
       
        
    }

    private async void InitializeAsync()
    {
        await list.getWordList();
        GenerateWord();
        await App.Current.MainPage.DisplayAlert("Generated Word", $"The generated word is: {new string(Word)}", "OK");
    }

    public bool newWord = true;
    public char[] Word;

    public async void GenerateWord()
    {
        Word = list.GenerateRandomWord().ToCharArray();
        
    }
    public void Enter()
    {
        if (columnsIndex != 5)
            return;

        var answer = Rows[rowsIndex].Validate(Word);
       
        if (answer)
        {
            App.Current.MainPage.DisplayAlert("You Win", "You Win", "OK");
            return;
        }

        if (rowsIndex == 5)
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

       


        if (columnsIndex == 5)
        {
            return;
        }
        
        Rows[rowsIndex].Letters[columnsIndex].Input = letter;
        columnsIndex++;
    }

}
