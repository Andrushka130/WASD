public class CharactersFactory
{
    public Characters GetCharacters(ECharacters character)
    {
        switch(character)
        {
            case ECharacters.CharOne: return new CharacterOne();
            
            default: return new CharacterOne();
        }
    }
}