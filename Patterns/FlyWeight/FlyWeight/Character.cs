namespace FlyWeight;

public class Character : ICharacter
{
    private char symbol;

    public Character(char symbol)
    {
        this.symbol = symbol;
    }

    public void Display(int fontSize)
    {
        Console.WriteLine($"Символ {symbol} с размером шрифта {fontSize}");
    }
}
