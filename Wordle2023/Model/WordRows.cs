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
    public void Validate(char[] correctLetter)
    {

    }

}

public partial class Letter : ObservableObject
{
    public Letter()
    {
        
        color = Colors.Black;
    }
    [ObservableProperty]
    private char input;

    [ObservableProperty]
    private Color color;

}
