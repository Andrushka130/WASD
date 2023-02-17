public class CharactersManager
{
    private static CharactersFactory _charactersFactory = new CharactersFactory();
    private static Characters currentChar = _charactersFactory.GetCharacters(ECharacters.CharOne);
    public static Characters CurrentChar { get { return currentChar;} }
    
    private static CharactersManager instance = null;
    private static readonly object padlock = new object();
    private CharactersManager()
    {
    }
    public static CharactersManager Instance
    {
        get
        {
        lock (padlock)
        {
            if (instance == null)
            {
            instance = new CharactersManager();
            }
            return instance;
        }
        }
    }

    public void ChangeCharacter(ECharacters character)
    {
        currentChar = _charactersFactory.GetCharacters(character);
    }
}
