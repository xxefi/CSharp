using FlyWeight;

class Program
{
    static void Main()
    {
        CharacterFactory characterFactory = new CharacterFactory();

        ICharacter a = characterFactory.GetCharacter('A');
        ICharacter b = characterFactory.GetCharacter('F');
        ICharacter c = characterFactory.GetCharacter('G');
        ICharacter d = characterFactory.GetCharacter('A');
        ICharacter e = characterFactory.GetCharacter('N');

        a.Display(12);
        b.Display(15);
        c.Display(18);
        d.Display(21);
        e.Display(27);
    }
}