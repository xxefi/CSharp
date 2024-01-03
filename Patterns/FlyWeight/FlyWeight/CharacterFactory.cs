namespace FlyWeight;

public class CharacterFactory
{
    private Dictionary<char, ICharacter> characters = new Dictionary<char, ICharacter>();

    public ICharacter GetCharacter(char symbol)
    {
        if (characters.ContainsKey(symbol) == false)
        {
            characters[symbol] = new Character(symbol);
        }
        return characters[symbol];
    }

}