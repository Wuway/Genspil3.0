namespace Genspil3._0
{
    //TODO: Vi overvejer om listerne skal flyttes ind i Game.cs og Request.cs
    internal class Lists
    {
        public static void ShowGamesTitle()
        {
            Console.Clear();
            Console.WriteLine("Lagerliste sortetet efter spillets navn.\n----------------------------------------\n");
            var games = Game.GetGames();
            

            // 1. Lav en ny liste og kopier alle spil fra 'games'
            List<Game> sortedGames = new List<Game>();

            // Kopier alle spil fra 'games' til 'sortedGames'
            foreach (Game game in games)
            {
                sortedGames.Add(game);
            }

            // 2. Sortér den nye liste efter titel
            sortedGames.Sort(CompareByTitle);

            foreach (var g in sortedGames)
            {
                Console.WriteLine($"Spil: {g.Title}\nUdgave: {g.Version}\nGenre: {g.Genre}\nMax antal spillere: {g.ParticipantGame}\nMin. aldersgrænse: {g.AgePlayerGame}\nStand: {g.Condition}\nPris: {g.PriceGame}\nAntal: {g.AmountGame}");
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("Indtast vilkårlig tast for at blive sendt til hovedmenuen.");
            Console.ReadLine();
        }

        private static int CompareByTitle(Game x, Game y) // Sammenligner to Game-objekter alfabetisk efter deres Title
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException("Et af Game-objekterne er null."); //
            }

            return string.Compare(x.Title, y.Title); //den skal bare ind i metoden comparebytitle// Sammenligner to Game-objekter alfabetisk efter deres Title
            //return x.Title.CompareTo(y.Title);
        }

        public static void ShowGamesGenre()
        {
            Console.Clear();
            Console.WriteLine("Lagerliste sorteret efter genre.\n--------------------------------");
            var games = Game.GetGames();
            

            // Lav en ny liste som kopi af den oprindelige liste med spil
            // sortedGenre er en kopi af listen 'games', som vi sorterer uden at ændre den oprindelige liste
            List<Game> sortedGenre = new List<Game>(games);

            // Ydre løkke: gentager sorteringen flere gange

            for (int i = 0; i < sortedGenre.Count - 1; i++)
            {
                // Indre løkke: sammenligner to spil ad gangen og bytter dem, hvis nødvendigt

                for (int j = 0; j < sortedGenre.Count - 1; j++)
                {
                    // Hvis spillet på position j har en genre, der kommer EFTER spillet på position j + 1
                    // CompareTo sammenligner genrerne af to spil: hvis spillet på position j er "større" end spillet på j+1, byttes de

                    if (sortedGenre[j].Genre.CompareTo(sortedGenre[j + 1].Genre) > 0)
                    {
                        // Byt rundt på de to spil
                        Game temp = sortedGenre[j];
                        sortedGenre[j] = sortedGenre[j + 1];
                        sortedGenre[j + 1] = temp;
                    }
                }
            }

            foreach (var g in sortedGenre)
            {
                Console.WriteLine($"Spil: {g.Title}\nUdgave: {g.Version}\nGenre: {g.Genre}\nMax antal spillere: {g.ParticipantGame}\nMin. aldersgrænse: {g.AgePlayerGame}\nStand: {g.Condition}\nPris: {g.PriceGame}\nAntal: {g.AmountGame}");
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("Indtast vilkårlig tast for at blive sendt til hovedmenuen.");
            Console.ReadLine();
        }
        public static void ShowRequests()
        {
            Console.Clear();
            Console.WriteLine("Liste over alle forespørgsler.\n--------------------------------------");
            var requests = Request.GetRequests();
            

            List<Request> Requests = new List<Request>(requests);

            Requests.Sort(CompareByName);


            foreach (var r in Requests)
            {
                Console.WriteLine($"Kunde: {r.Name}\nEmail: {r.Email}\nTelefon: {r.Phone}\nTitel: {r.Title}\nUdgave: {r.Version}\nØnsket stand: {r.Condition}\n");
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("Indtast vilkårlig tast for at blive sendt til hovedmenuen.");
            Console.ReadLine();
        }
        private static int CompareByName(Request x, Request y) // Sammenligner to Request-objekter alfabetisk efter deres Name
        {
            // Sammenligner to Request-objekter alfabetisk efter deres Name
            return x.Name.CompareTo(y.Name);
        }
    }
}