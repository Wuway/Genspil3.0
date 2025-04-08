namespace Genspil3._0
{
    public static class DataHandler
    {
        ///OBS TODO jeg er i tvivl om objektet File skal være noget andet?

        //Her gemmer den en liste af data til en fil. Listen kaldes File, filePath er stien hvor filen gemmes.
        public static void SaveToFile<File>(string filePath, List<File> data)
        {
            //Opretter en streamwriter til at skrive filen på den valgte sti.
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //Initierer gennem hvert objekt i listen og skriver det til filen som en streng.
                foreach (var item in data)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
        //Indlæser listen af data fra en fil.
        public static List<File> LoadFromFile<File>(string filePath)
        {
            //Opretter en ny liste til at indholde de indlæste data. Streamreader læser filen fra den valgte sti.
            List<File> data = new List<File>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    File item = (File)Convert.ChangeType(line, typeof(File));
                    data.Add(item);
                }
            }
            //Returnerer indlæst data til listen.
            return data;
        }
    }
}
