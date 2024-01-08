using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Wordle2023.Model;

public class WordRows : ObservableObject
{
    public WordRows()
    {
        //initialize the letters
        Letters = new Letter[5]
        {
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter()
        };      
    }
    private Letter[] letters;

    public Letter[] Letters
    {
        get { return letters; }
        set { SetProperty(ref letters, value); }
    }

    //Method to Validate the word
    public bool Validate(char[] Word)
    {
        int count = 0;
        for (int i = 0; i < Letters.Length; i++)
        {
            var letter = Letters[i];

            //Convert the input and Answer to upper case
            char inputUpperCase = char.ToUpperInvariant(letter.Input); // Convert input to upper case
            char expectedUpperCase = char.ToUpperInvariant(Word[i]);

            //debug for checking the input and answer
            Debug.WriteLine($"Input: {letter.Input}, Expected: {Word[i]}");

            //Check if the input is correct
            if (inputUpperCase == expectedUpperCase)
            {
                
                letter.Color = Colors.Green;
                letter.IsCorrect = true;
                count++;
            }
            else if (Word.Contains(letter.Input) || Word.Contains(char.ToLowerInvariant(letter.Input)))
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
    //Declare IsCorrect, Input and Color
    private bool isCorrect;

    public bool IsCorrect
    {
        get { return isCorrect; }
        set { SetProperty(ref isCorrect, value); }
    }

    private char input;

    public char Input
    {
        get { return input; }
        set { SetProperty(ref input, value); }
    }

    private Color color;

    public Color Color
    {
        get { return color; }
        set { SetProperty(ref color, value); }
    }
}

