namespace Genspil3._0
{
    internal class Search
    {
        public static void ShowSearchGameResults()
        {
            Console.Clear();
            Console.WriteLine("Indtast titel (eller tryk enter for at springe over):");
            string title = Console.ReadLine();
            Console.WriteLine("Indtast genre (eller tryk enter for at springe over):");
            string genre = Console.ReadLine();
            Console.WriteLine("Indtast pris (eller tryk enter for at springe over):");
            string priceInput = Console.ReadLine();
            double? price = string.IsNullOrEmpty(priceInput) ? (double?)null : double.Parse(priceInput);

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
                string upperSaveGame = saveGame.ToUpper();

                if (upperSaveGame == "JA")
                {
                    Request request = new Request();
                    //FORKLARING: TJEKKER OM Request.requests er null. Hvis null, laves en ny instance af List<Request>. Hvis ikke null, bruges den eksisterende liste
                    Request.requests = Request.requests ?? new List<Request>();
                    //FORKLARING: while løkke der fortsætter med at udføre, så længe betingelsen inde i parentesen evalueres til "true"   
                    while (request.AddRequest(Request.requests)) { }
                }
            }
            Console.WriteLine("Indtast vilkårlig tast for at blive sendt til hovedmenuen.");
            Console.ReadLine();
        }
        
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
                foreach (var r in results)
                {
                    Console.WriteLine($"Navn: {r.Name} \nEmail: {r.Email}\nTlfnr. {r.Phone}\nSpil: {r.Title}\nUdgave: {r.Version}\nØnsket stand (som minimum): {r.Condition}\n.");
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Der er ingen forespørgsler i systemet, der matcher de angive kriterier.\nVil du oprette en forespørgsel på kunden? (Ja / Nej)");
                string makeRequest = Console.ReadLine();
                string upperMakeRequest = makeRequest.ToUpper();

                if (upperMakeRequest == "JA")
                {
                    Request request = new Request();
                    //FORKLARING: TJEKKER OM Request.requests er null. Hvis null, laves en ny instance af List<Request>. Hvis ikke null, bruges den eksisterende liste
                    Request.requests = Request.requests ?? new List<Request>();
                    //FORKLARING: while løkke der fortsætter med at udføre, så længe betingelsen inde i parentesen evalueres til "true"                
                    while (request.AddRequest(Request.requests)) { }
                }
            }
            Console.WriteLine("Indtast vilkårlig tast for at blive sendt til hovedmenuen.");
            Console.ReadLine();
        }

        
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