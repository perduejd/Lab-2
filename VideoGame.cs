using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2
{
    public class VideoGame : IComparable<VideoGame>
    {
        // CSV Properties
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string NA_Sales { get; set; }
        public string EU_Sales { get; set; }
        public string JP_Sales { get; set; }
        public string Other_Sales { get; set; }
        public string Global_Sales { get; set; }

        public static VideoGame FromFile(string line) // Method to read the CSV file
        {
            string[] info = line.Split(',');
            VideoGame reader = new VideoGame();
            reader.Name = Convert.ToString(info[0]);
            reader.Platform = Convert.ToString(info[1]);
            reader.Year = Convert.ToInt32(info[2]);
            reader.Genre = Convert.ToString(info[3]);
            reader.Publisher = Convert.ToString(info[4]);
            reader.NA_Sales = Convert.ToString(info[5]);
            reader.EU_Sales = Convert.ToString(info[6]);
            reader.JP_Sales = Convert.ToString(info[7]);
            reader.Other_Sales = Convert.ToString(info[8]);
            reader.Global_Sales = Convert.ToString(info[9]);
            return reader;
        }

        public int CompareTo(VideoGame other) // Method to compare the global sales of the videogames
        {
            if (other == null)
            {
                return 1;
            }
            return string.Compare(Global_Sales, other.Global_Sales, StringComparison.OrdinalIgnoreCase); // Comparing the global sales of the videogames
        }

        public static void Scope() // Scope method to grab the top 5 videogames
        { 
            List<VideoGame> videogame = (from v in File.ReadAllLines("C:\\Users\\12766\\source\\repos\\Lab1\\Lab1\\videogames.csv").Skip(1) // .csv location
                                         select FromFile(v)).ToList();

            videogame.Sort();
            videogame.Reverse();

            Dictionary<string, List<string>> gamebyPlatform = (from game in videogame // Locating the top 5 video games for each platform located in the csv file
                                                               group game by game.Platform into platform
                                                               select new
                                                               {
                                                                   Platform = platform.Key,
                                                                   Games = (from game in platform select game.Name).ToList()
                                                               }).ToDictionary(x => x.Platform, x => x.Games);

            foreach (var platform in gamebyPlatform) // Grabbing the top 5 video games by platform
            {
                Console.WriteLine($"Platform: {platform.Key}");
                var topGames = platform.Value.Take(5); // Grabbing top 5 video games
                foreach (var game in topGames)
                {
                    Console.WriteLine($"\t{game}");
                }
            }
        }
    }
}