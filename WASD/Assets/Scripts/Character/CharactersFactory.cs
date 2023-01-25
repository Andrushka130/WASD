public class CharactersFactory
{
    public Characters GetCharacters(ECharacters character)
    {
        switch(character)
        {
            case ECharacters.CharOne: return new CharacterOne(); break;
            
            default: return new CharacterOne(); break;
        }
    }
}