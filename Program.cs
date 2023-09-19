namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                VideoGame.Scope(); // Scope created to grab the top 5 videogames
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File cannot be found."); // Exception of file not being found
            }

        }
    }
}