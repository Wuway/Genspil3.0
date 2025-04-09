namespace Genspil3._0
{
    class Request
    {
        
        private string nameRequest;
        private string emailRequest;
        private string phoneRequest;
        private string titleRequest;
        private string versionRequest;
        private char conditionRequest;

        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public char Condition { get; set; }

        public static List<Request> requests = new List<Request>();
        private const string filePath = "requests.txt";
        //TODO: Ved implementering filhåndtering, har vi ikke langere brug for predefinerede data som i metoden nedunder = kan indlæse data fra extern fil.
        public static void InitializedPredefinedRequests()
        {
            //tilføjer foruddefinerede forespørgsler
            requests.Add(new Request { nameRequest = "Morten Jensen", emailRequest = "morten.jensen@gmail.com", phoneRequest = "22419866", titleRequest = "Uno", versionRequest = "udviddet", conditionRequest = 'B' });
            requests.Add(new Request { nameRequest = "Anne Hansen", emailRequest = "annehansen88@gmail.com", phoneRequest = "61582274", titleRequest = "Partners", versionRequest = "standard", conditionRequest = 'A' });
            SaveRequestsToFile();
        }
        //Constructor brugt til at intitialisere predefinerede data ovenover
        public Request() { }
        //Constructor til at initialisere user definerede game objekter
        public Request(string nameRequest, string emailRequest, string phoneRequest, string titleRequest, string versionRequest, char conditionRequest)
        {
            Name = nameRequest;
            Email = emailRequest;
            Phone = phoneRequest;
            Title = titleRequest;
            Version = versionRequest;
            Condition = conditionRequest;
        }
        public bool AddRequest(List<Request> listRequests)
        {
            Console.Clear();
            Console.WriteLine("Du har valgt at oprette en forespørgsel. Indtast følgende oplysninger:\n-----------------------------------------------------------------------");
            Console.WriteLine("Indtast kundens navn og efternavn: ");
            string nameRequest = Console.ReadLine();
            Console.WriteLine("Din e-mail: ");
            string emailRequest = Console.ReadLine();
            Console.WriteLine("Dit telefonnummer: ");
            string phoneRequest = Console.ReadLine();
            Console.WriteLine("Spillets navn: ");
            string titleRequest = Console.ReadLine();
            Console.WriteLine("Udgave: ");
            string versionRequest = Console.ReadLine();
            Console.WriteLine("Indtast ønsket stand, som minimum - (nyt (A), god men brugt (B), slidt (C) og reperation (D): ");//TODO: Hvis implementering af enum i game klasse, tilpas her.
            char.TryParse(Console.ReadLine(), out char conditionRequest);//TODO: hvis enum implementeres i game klasse, så tilpas her.
            Console.WriteLine("Vil du gemme forespørgslen ? (Ja / Nej)\n");
            string saveRequest = Console.ReadLine();
            string upperSaveRequest = saveRequest.ToUpper();//TODO: flyt To.Upper() metoden sammen med Console.Readline(), fjern upperSaveRequest. erstat upperSaveRequest i if parameter nedunder med saveRequest.

            if (upperSaveRequest == "JA")
            {
                Console.Clear();
                Request newRequest = new Request(nameRequest, emailRequest, phoneRequest, titleRequest, versionRequest, conditionRequest);
                requests.Add(newRequest);
                SaveRequestsToFile();
                Console.WriteLine($"Navn: {nameRequest} \nEmail: {emailRequest}\nTlfnr. {phoneRequest}\nSpil: {titleRequest}\nUdgave: {versionRequest}\nØnsket stand (som minimum): {conditionRequest}\n");
                Console.WriteLine("Forespørgslen er gemt. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Forespørgslen er annulleret. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            return false; // Return false to break the loop in Program.cs
        }

        public static List<Request> GetRequests()//Metode til at returnere alle request i request listen.
        {
            return requests;
        }
        public override string ToString()
        {
            return $"Navn: {Name} \nEmail: {Email}\nTlfnr. {Phone}\nSpil: {Title}\nUdgave: {Version}\nØnsket stand (som minimum): {Condition}\n";
        }
        public static void SaveRequestsToFile()
        {
            DataHandler.SaveToFile(filePath, requests);
        }
        public static void LoadRequestsFromFile()
        {
            requests = DataHandler.LoadFromFile<Request>(filePath);
        }
    }
}