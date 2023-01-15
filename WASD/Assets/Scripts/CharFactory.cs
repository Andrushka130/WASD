public class CharFactory
{
    public CharacterAttribute GetCharAttribute(string character)
    {
        switch(character) {
            case "char1": new CharacterAttribute(); break;
        }
    }
}