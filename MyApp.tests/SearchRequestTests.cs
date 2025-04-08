public class Request // Skift fra 'private' eller 'internal' til 'public'
{
    // Private variabler bliver stadig private
    private string nameRequest;
    private string emailRequest;
    private string phoneRequest;
    private string titleRequest;
    private string versionRequest;
    private char conditionRequest;

    // Offentlige properties
    public string Name { get { return nameRequest; } set { nameRequest = value; } }
    public string Email { get { return emailRequest; } set { emailRequest = value; } }
    public string Phone { get { return phoneRequest; } set { phoneRequest = value; } }
    public string Title { get { return titleRequest; } set { titleRequest = value; } }
    public string Version { get { return versionRequest; } set { versionRequest = value; } }
    public char Condition { get { return conditionRequest; } set { conditionRequest = value; } }

    // Offentlig statisk liste af forespørgsler
    public static List<Request> requests = new List<Request>();  // Gør denne public

   
}

