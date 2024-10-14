
namespace Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Parsing begins...");

            //var changesParser = new ChangesParser();
            var anotherChangeParser = new AnotherChangeParser();

            string filePath = "/Users/user/dotnet_projects/Parser/Parser/Resource/ChangeHistory.txt"; // Path to input file
            string saveFile = "/Users/user/dotnet_projects/Parser/Parser/Resource/ParsedChangeHistory.txt"; // Path to output file

            try
            {
                //changesParser.Parse(filePath);
                //changesParser.SaveParsedData(saveFile);
                //Console.WriteLine($"Parsing completed successfully. Parsed data saved to {saveFile}.");
                anotherChangeParser.Parsing(filePath);
                anotherChangeParser.SaveParsedData(saveFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }


}
