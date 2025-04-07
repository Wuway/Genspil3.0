using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil3._0
{
    class Game
    {
        //TODO: Sæt variablene på samme linje
        private string titleGame;
        private string versionGame;
        private string genreGame;
        private int participantGame;
        private int agePlayerGame;
        private char conditionGame;
        private double priceGame;
        private int amountGame;

        //TODO: Tilføj nogle betingelser
        public string Title//TODO: eksempel betingelse: ToUpper (se searchshowgameresults()
        {
            get { return titleGame; }
            set { titleGame = value; }
        }
        public string Version
        {
            get { return versionGame; }
            set { versionGame = value; }
        }
        public string Genre//TODO: eksempel betingelse: ToUpper (se searchshowgameresults()
        {
            get { return genreGame; }
            set { genreGame = value; }
        }
        public int ParticipantGame
        {
            get { return participantGame; }
            set { participantGame = value; }
        }
        public int AgePlayerGame
        {
            get { return agePlayerGame; }
            set { agePlayerGame = value; }
        }
        //TODO: lave ConditionGame om til ENUM
        //OBS: Jeg har tilføjet en enum nedenunder, men resten af koden skal tilpasses! Kennie
        public char ConditionGame
        {
            get { return conditionGame; }
            set { conditionGame = value; }
        }
        //Enum til at definere betingelserne for spillet
        public enum ConditionOfGame
        {
            Repair = '0',
            Poor = '1',
            Good = '2',
            Excellent = '3',
            New = '4'

        }
        //Betingelse for PriceGame er lagt ind. Kennie
        public double PriceGame
        {
            get { return priceGame; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Prisen kan ikke være negativ. Indtast venligst en gyldig pris.");
                    return;
                }
                else
                    priceGame = value;
            }
        }
        public int AmountGame
        {
            get { return amountGame; }
            set { amountGame = value; }
        }

        private static List<Game> games = new List<Game>();
        private const string filePath = "games.txt";
        //TODO: Ved implementering filhåndtering, har vi ikke langere brug for predefinerede data som i metoden nedunder = kan indlæse data fra extern fil.
        public static void InitializedPredefinedGames()//Fordefinerede data i listen, som vi kan bruge i programmet til at teste funktionalitet.
        {
            //tilføjer foruddefinerede spil og kalder metode til at føre objekterne ind i vores txt fil.
            Console.Clear();
            games.Add(new Game { titleGame = "Trivial Pursuit", versionGame = "Disney", genreGame = "Børn", participantGame = 2, agePlayerGame = 8, conditionGame = 'C', priceGame = 109, amountGame = 2 });
            games.Add(new Game { titleGame = "Sequence", versionGame = "Jubilæum", genreGame = "Voksne", participantGame = 4, agePlayerGame = 18, conditionGame = 'A', priceGame = 199, amountGame = 1 });
            games.Add(new Game { titleGame = "Bad People", versionGame = "Original", genreGame = "Strategi", participantGame = 2, agePlayerGame = 8, conditionGame = 'B', priceGame = 149, amountGame = 0 });
            games.Add(new Game { titleGame = "Ticket To Ride", versionGame = "Junior", genreGame = "Børn", participantGame = 4, agePlayerGame = 6, conditionGame = 'B', priceGame = 109, amountGame = 1 });
            SaveGamesToFile();
        }
        //Constructor brugt til at intitialisere predefinerede data ovenover
        public Game() { }//TODO: flyt til linje 70 (før constructor)

        //Constructor til at initialisere user definerede game objekter
        public Game(string titleGame, string versionGame, string genreGame, int participantGame, int agePlayerGame, char conditionGame, double priceGame, int amountGame)
        {
            Title = titleGame;
            Version = versionGame;
            Genre = genreGame;
            ParticipantGame = participantGame;
            AgePlayerGame = agePlayerGame;
            ConditionGame = conditionGame;
            PriceGame = priceGame;
            AmountGame = amountGame;
        }
        public bool AddGame()
        {
            Console.Clear();
            Console.WriteLine("Du har valgt at oprette et spil i lageret. Tilføj følgende oplysninger:\n-----------------------------------------------------------------------");
            Console.WriteLine("Spillets navn: ");
            string titleGame = Console.ReadLine();
            Console.WriteLine("Udgave: ");
            string versionGame = Console.ReadLine();
            Console.WriteLine("Spillets genre: ");
            string genreGame = Console.ReadLine();
            Console.WriteLine("Max antal spillere: ");
            int participantGame = int.Parse(Console.ReadLine());
            Console.WriteLine("Spillets aldersgrænse (min. alder): ");
            int agePlayerGame = int.Parse(Console.ReadLine());
            Console.WriteLine("Spillets stand nyt (A), god men brugt (B), slidt (C) og reperation (D): ");
            char conditionGame = char.Parse(Console.ReadLine());//TODO: Hvis implementering af enum i game klasse, tilpas her.
            char upperConditionGame = char.ToUpper(conditionGame);
            Console.WriteLine("Spillets pris: ");
            double priceGame = double.Parse(Console.ReadLine());
            Console.WriteLine("Tilføj antal: ");
            int amountGame = int.Parse(Console.ReadLine());
            Console.WriteLine("Vil du gemme ? (Ja / Nej)");
            string saveGame = Console.ReadLine();
            string upperSaveGame = saveGame.ToUpper();//TODO: flyt To.Upper() metoden sammen med Console.Readline(), fjern upperSaveGame. erstat upperSaveGame i if parameter nedunder med saveGame.

            if (upperSaveGame == "JA")
            {
                Console.Clear();
                Game newGame = new Game(titleGame, versionGame, genreGame, participantGame, agePlayerGame, conditionGame, priceGame, amountGame);
                games.Add(newGame);
                SaveGamesToFile();
                Console.WriteLine($"Spil: {titleGame}\nUdgave: {versionGame}\nGenre: {genreGame}\nMax antal spillere: {participantGame}\nMin. aldersgrænse: {agePlayerGame}\nStand: {conditionGame}\nPris: {priceGame}\nAntal: {amountGame}\n");
                Console.WriteLine("Spillet er gemt. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Spillet er ikke gemt. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            return false; // Return false for at bryde loopet i Menuchoice.cs
        }

        public static List<Game> GetGames() //Metode til at returnere alle spil i games listen.
        {
            return games;
        }
        public override string ToString()
        {
            return $"Spil: {titleGame}\nUdgave: {versionGame}\nGenre: {genreGame}\nMax antal spillere: {participantGame}\nMin. aldersgrænse: {agePlayerGame}\nStand: {conditionGame}\nPris: {priceGame}\nAntal: {amountGame}";
        }

        public static void DeleteGame()
        {
            Console.Clear();
            Console.WriteLine("Du har valgt, at du vil slette et spil. Vælg mellem følgende:\n\n");
            Console.WriteLine("Lagerliste sorteret efter titel:\n--------------------------------");
            var sortedGenre = games.OrderBy(g => g.genreGame).ToList();//TODO: find alternativer til lambda's
            foreach (var g in sortedGenre)//TODO: valg mere beskrivende end "g" f.eks "item"
            {
                Console.WriteLine($"Spil: {g.titleGame}\nUdgave: {g.versionGame}\nGenre: {g.genreGame}\nMax antal spillere: {g.participantGame}\nMin. aldersgrænse: {g.agePlayerGame}\nStand: {g.conditionGame}\nPris: {g.priceGame}\nAntal: {g.amountGame}");
                Console.WriteLine("-----------------------------------\n");
            }
            Console.WriteLine("Indtast spillets navn du ønsker slettet: ");
            string deleteGame = Console.ReadLine().ToUpper();//TODO: give Kristina klap på skulderen
            var game = games.FirstOrDefault(g => g.titleGame.ToUpper() == deleteGame);//TODO: Find anden metode 
            if (game != null)
            {
                Console.WriteLine("Indtast det antal du ønsker slettet: ");
                int deleteAmount = int.Parse(Console.ReadLine());//TODO: TryParse?
                if (game.amountGame >= deleteAmount)
                {
                    game.amountGame -= deleteAmount;
                    if (game.amountGame == 0)
                    {
                        games.Remove(game);//Kalder metoden Remove med game paramter på listobjekten games til at fjerne et bestemt spil.
                        Console.Clear();
                        Console.WriteLine("Spillet er slettet fra lagerlisten.\n\nIndtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Spillet er slettet. Antallet af spil '{deleteGame}' er reduceret med {deleteAmount}.\n\nOpdateret lagerstatus for det valgte spil er nu: {game.amountGame}.\n\nIndtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Der er ikke nok spil på lager til at slette det ønskede antal.\n\nIndtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                    Console.ReadLine();
                    return;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Spillet findes ikke på lagerlisten. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
                return;
            }
        }

        public static void SaveGamesToFile()
        {
            DataHandler.SaveToFile(filePath, games);
        }
        public static void LoadGamesFromFile()
        {
            if (File.Exists(filePath))
            {
                games = DataHandler.LoadFromFile<Game>(filePath);
            }
        }
    }
}
