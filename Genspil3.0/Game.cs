using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil3._0
{
    public class Game
    {
        private string titleGame;
        private string versionGame;
        private string genreGame;
        private int participantGame;
        private int agePlayerGame;
        private char conditionGame;
        private double priceGame;
        private int amountGame;
        public string Title { get; set; }
        public string Version { get; set; }
        public string Genre { get; set; }
        public int ParticipantGame { get; set; }
        public int AgePlayerGame { get; set; }
        public char ConditionGame { get; set; }
        public enum ConditionOfGame
        {
            Repair = 48,
            Poor = 49,
            Good = 50,
            Excellent = 51,
            New = 52
        }
        public double PriceGame { get; set; }
        public int AmountGame { get; set; }
        private static List<Game> games;
        private const string filePath = "games.txt";
        public static void InitializedPredefinedGames() { }
        public bool AddGame() { return true; }
        public static List<Game> GetGames() { return new List<Game>(); }
        public override string ToString() { return ""; }
        public static void DeleteGame() { }
        public static void SaveGamesToFile() { }
        public static void LoadGamesFromFile() { }
    }
}
