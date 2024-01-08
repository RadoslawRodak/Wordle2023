using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Wordle2023.Model;

namespace Wordle2023.GameView
{
    public partial class GameViewModel : ObservableObject
    {
        //load the list of words
        ListOfWords list;

        //index of the current row and column
        int rowsIndex;
        int columnsIndex;

        //Keyboard
        public char[] keyboard1 { get; }
        public char[] keyboard2 { get; }
        public char[] keyboard3 { get; }

        [ObservableProperty]
        private WordRows[] rows;


        public GameViewModel()
        {
            //initialize the list of words
            list = new ListOfWords();

            //initialize the rows of the game
            rows = new WordRows[6]
            {
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows()
            };

            //initialize the keyboard
            keyboard1 = "QWERTYUIOP".ToCharArray();
            keyboard2 = "ASDFGHJKL".ToCharArray();
            keyboard3 = "<ZXCVBNM>".ToCharArray();

            InitializeAsync();
        }

        
        private async void InitializeAsync()
        {
            //Generate a new word from the List
            await list.getWordList();
            GenerateWord();
        }

        public bool newWord = true;
        public char[] Word;


        
        public async void GenerateWord()
        {
            //generate a new word
            Word = list.GenerateRandomWord().ToCharArray();
        }

        //handle the input of the user
        [RelayCommand]
        public async void EnterLetter(char letter)
        {
            if (letter == '>')
            {
                Enter();
                return;
            }

            if (letter == '<')
            {
                if (columnsIndex == 0)
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

        // Method for reseting the game
        private void ResetGame()
        {
            rowsIndex = 0;
            columnsIndex = 0;
            newWord = true;

            foreach (var row in Rows)
            {
                for (int i = 0; i < row.Letters.Length; i++)
                {
                    row.Letters[i].Input = ' ';
                    row.Letters[i].Color = Colors.White;
                    row.Letters[i].IsCorrect = false;
                }
            }

            GenerateWord();
            OnPropertyChanged(nameof(Rows));
            OnPropertyChanged(nameof(Word));
        }

        // Method for handling the game end
        private void HandleGameEnd(string title, string message)
        {
            App.Current.MainPage.DisplayAlert(title, message, "OK");
            ResetGame();
        }

        [RelayCommand]
        public void Enter()
        {
            if (columnsIndex != 5)
                return;

            // Converts the letters in the current row to a string
            var enteredWord = new string(Rows[rowsIndex].Letters.Select(l => char.ToLowerInvariant(l.Input)).ToArray()).Trim();

            // Debug
            Debug.WriteLine($"Entered Word: {enteredWord}, Expected Word: {new string(Word)}");

            // Check if the entered word is in the list and if the word is correct
            if (list.WordExists(enteredWord))
            {
                var answer = Rows[rowsIndex].Validate(Word);
         
                var expectedWord = new string(Word).ToLowerInvariant();

                if (answer)
                {
                    HandleGameEnd("You Win", "You Win");
                    return;
                }

                if (rowsIndex == 5)
                {
                    HandleGameEnd("Game Over", "Out of Turns");
                }
                else
                {
                    rowsIndex++;
                    columnsIndex = 0;
                }
            }
            else
            {
                // Display an alert if the entered word is not in the list
                App.Current.MainPage.DisplayAlert("Invalid Word", "The entered word is not in the list.", "OK");
                ClearCurrentLine();
            }
        }

        // Method for clearing the current line
        private void ClearCurrentLine()
        {
            foreach (var letter in Rows[rowsIndex].Letters)
            {
                letter.Input = ' ';
            }

            columnsIndex = 0;
        }
    }
}
