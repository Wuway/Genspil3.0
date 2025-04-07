namespace Genspil3._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialiserer foruddefinerede spil
            Game.InitializedPredefinedGames();
            Request.InitializedPredefinedRequests();

            //Initialiserer nye lister
            List<Request> requests = new List<Request>();
            List<Game> listsortedGames = new List<Game>();
            List<Game> listsortedGenre = new List<Game>();
            // Vi har overvejet at lave en separat klasse til menu.
            int menuchoice;
            // TODO: fjern unnødvendig kode til switch case. Tilføj default case.
            do
            {
                Console.Clear();
                Console.WriteLine("\nVelkommen til Genspil! Vi er en spilforretning med fokus på genbrug for at passe på vores miljø.\n\n");
                Console.WriteLine("Tast 1 for: opret spil.\n\nTast 2 for: søg på spil.\n\nTast 3 for: lagerliste efter navn.\n\nTast 4 for: lagerliste efter genre.\n\nTast 5 for: opret forespørgsel.\n\nTast 6 for: søg på forespørgsel.\n\nTast 7 for: se alle forespørgsler.\n\nTast 8 for: slet spil.\n\nTast 9 for: luk program.\n");
                Console.WriteLine("-----------------------------------------------\n");
                //ændret linje 25 til TryParse
                /*menuchoice = */
                int.TryParse(Console.ReadLine(), out menuchoice);//hvis input kan valideres, så sendes videre til menuchoice. Ellers bliver den null.

                //Udkommenteret unødvendig dobbelt kode til at validere input fra brugeren. Kennie

                /*if (menuchoice < 1 || menuchoice > 9)
                {
                    Console.WriteLine("Du har tastet forkert. Prøv igen.");
                }
                else
                {*/


                switch (menuchoice)
                {
                    case 1: //opret spil
                        Game game = new Game();
                        while (game.AddGame()) { }
                        break;
                    case 2:  //søg på spil efter ..* kriterier
                        Search.ShowSearchGameResults();
                        break;
                    case 3: //se liste over spil sorteret alfabetisk efter navn
                        Lists.ShowGamesTitle();
                        break;
                    case 4: //se liste over spil sorteret alfabetisk efter genre
                        Lists.ShowGamesGenre();
                        break;
                    case 5: //opret forespørgsel
                        Request request = new Request();
                        while (request.AddRequest(requests)) { }
                        break;
                    case 6: //søg på forespørgsel efter ..* kriterier
                        Search.ShowSearchRequestResults();
                        break;
                    case 7: //se alle forespørgsler OBS tilføjer ikke de nye forespørgsler til listen!
                        Lists.ShowRequests();
                        break;
                    case 8: //slet spil
                        Game.DeleteGame();
                        break;
                    case 9://afslut switch og luk konsol vinduet.
                        Console.WriteLine("Du har valgt at afslutte programmet. Tak for nu!");
                        Environment.Exit(0);//Kalder klassen Environment, så vi kan kalder på methoden Exit.
                                            //TODO: Find alternativ til metoden ovenfor. f.eks deklarerer menuchoice øverst til 1, og sæt menuchoice lige med 0 i case 9.
                        break;
                    default:
                        //Jeg har leget lidt med farverne i skærmen med Console.ForegroundColor og Console.BackgroundColor.

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;

                        Console.WriteLine("\t-------------------- FEJL ---------------------");
                        Console.ResetColor();

                        //Console.ResetColor(); nulstiller farven.

                        Console.Write("\n\nTryk på en vilkårlig tast for at");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" PRØVE IGEN");

                        Console.ResetColor();

                        Console.ReadKey();

                        menuchoice = 4; //Sætter betingelsen til en værdi som er gyldig, så den kan fortsætte i loopet. (menu kører igen)

                        break;
                }
                //}
            } while (menuchoice >= 1 && menuchoice <= 9);

            Console.ReadLine();
        }
    }
}