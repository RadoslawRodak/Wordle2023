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
            if(letter.Input == correctWord[i])
            {
                letter.Color = Colors.Green;
                count++;
            }
            else if(correctWord.Contains(letter.Input))
            {
                letter.Color = Colors.Yellow;
            }
            else
            {
                letter.Color = Colors.Gray;
            }
        }
        
        return count == 5;
    }

}

public partial class Letter : ObservableObject
{
    public Letter()
    {


        
        color = Colors.White;
    }
    [ObservableProperty]
    private char input;

    [ObservableProperty]
    private Color color;

}
