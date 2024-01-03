using CommunityToolkit.Mvvm.ComponentModel;

namespace Wordle2023.Model;

public class WordRows
{

    public WordRows()
    {
        Letters = new Letter[5]
        {
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter()

        };
    }
    public Letter[] Letters { get; set; }


    public bool Validate(char[] correctWord)
    {
        int count = 0;


        for (int i = 0; i < Letters.Length; i++)
        {
            var letter = Letters[i];

            if (letter.Input == correctWord[i])
            {
                letter.Color = Colors.Green;
                letter.IsCorrect = true;
                count++;
            }
            else if (correctWord.Contains(letter.Input))
            {
                letter.Color = Colors.Yellow;
                letter.IsCorrect = false;
            }
            else
            {
                letter.Color = Colors.Gray;
                letter.IsCorrect = false;
            }
        }

        return count == 5;
    }

}

public partial class Letter : ObservableObject
{

    private bool isCorrect;

    
    public bool IsCorrect
    {
        get { return isCorrect; }
        set { SetProperty(ref isCorrect, value); }
    }
    public Letter()
    {
        //change color depending on light or dark mode
        color = Colors.White;

    }
    [ObservableProperty]
    private char input;

    [ObservableProperty]
    private Color color;

}
