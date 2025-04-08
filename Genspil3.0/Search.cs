namespace Genspil3._0
{
    internal class Search
    {
        public static void ShowSearchGameResults()
        {
            Console.Clear();
            Console.WriteLine("Indtast titel (eller tryk enter for at springe over):");
            string title = Console.ReadLine();//TODO: tilføj To Upper?
            Console.WriteLine("Indtast genre (eller tryk enter for at springe over):");
            string genre = Console.ReadLine();//TODO: tilføj To Upper?
            Console.WriteLine("Indtast pris (eller tryk enter for at springe over):");
            string priceInput = Console.ReadLine();//TODO: lave om til double datatype, brug double.Parse.
            double? price = string.IsNullOrEmpty(priceInput) ? (double?)null : double.Parse(priceInput);//TODO: ternary expression, muligvis find alternativ (f.eks if-else)

            var results = SearchGame(title, genre, price);
            Console.Clear();
            if (results.Any())
            {
                Console.WriteLine("Søgeresultater:\n-----------------");
                foreach (var g in results)
                {
                    Console.WriteLine($"Spil: {g.Title}\nUdgave: {g.Version}\nGenre: {g.Genre}\nMax antal spillere: {g.ParticipantGame}\nMin. aldersgrænse: {g.AgePlayerGame}\nStand: {g.Condition}\nPris: {g.PriceGame}\nAntal: {g.AmountGame}");
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen spil matchede de angive kriterier.\nVil du oprette en forespørgsel på det? (Ja / Nej)");
                string saveGame = Console.ReadLine();
                string upperSaveGame = saveGame.ToUpper();//TODO To Upper til saveGame, brug saveGame i if parameter?

                if (upperSaveGame == "JA")
                {
                    Request request = new Request();
                    Request.requests = Request.requests ?? new List<Request>();//TODO: forklaring/ændring til spørgsmål
                    while (request.AddRequest(Request.requests)) { }
                }
            }
            Console.WriteLine("Indtast vilkårlig tast for at blive sendt til hovedmenuen.");
            Console.ReadLine();
        }
        //TO DO: find alternativ til 3 lambda expressions i if statements
        public static List<Game> SearchGame(string title = null, string genre = null, double? price = null)
        {
            Console.Clear();
            var games = Game.GetGames();
            var foundGames = new List<Game>();
            foreach (var g in games)
            {
                if (g.Title == title) //&& g.Genre == genre && g.PriceGame == price)
                {
                    foundGames.Add(g);
                }
                
            }

            return foundGames;
        }
        public static void ShowSearchRequestResults()
        {
            Console.Clear();
            Console.WriteLine("Indtast for- og efternavn på kunden (eller tryk enter for at springe over):");
            string name = Console.ReadLine();
            Console.WriteLine("Indtast telefonnummer på kunden (eller tryk enter for at springe over):");
            string phone = Console.ReadLine();

            var results = SearchRequest(name, phone);
            if (results.Any())
            {
                Console.WriteLine("Søgeresultater:\n-----------------");
                foreach (var r in results)//TODO: alternativ til "r", lidt mere beskrivende
                {
                    Console.WriteLine($"Navn: {r.Name} \nEmail: {r.Email}\nTlfnr. {r.Phone}\nSpil: {r.Title}\nUdgave: {r.Version}\nØnsket stand (som minimum): {r.Condition}\n.");
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Der er ingen forespørgsler i systemet, der matcher de angive kriterier.\nVil du oprette en forespørgsel på kunden? (Ja / Nej)");
                string makeRequest = Console.ReadLine();
                string upperMakeRequest = makeRequest.ToUpper();//TODO: to upper?

                if (upperMakeRequest == "JA")
                {
                    Request request = new Request();
                    Request.requests = Request.requests ?? new List<Request>();//TODO: forklaring/ændring til spørgsmål
                    while (request.AddRequest(Request.requests)) { }
                }
            }
            Console.WriteLine("Indtast vilkårlig tast for at blive sendt til hovedmenuen.");
            Console.ReadLine();
        }

        //TODO: alternativ til lambda's i if statements
        public static List<Request> SearchRequest(string name = null, string phone = null)
        {
            Console.Clear();
            var requests = Request.GetRequests();
            var foundRequest = new List<Request>();
            foreach (var r in requests)
            {
                if (r.Name == name) //&& r.Phone == phone)
                {
                    foundRequest.Add(r);
                }
            }
            
            return foundRequest;
        }
    }
}