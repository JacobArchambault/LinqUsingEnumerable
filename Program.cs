using System;
using System.Linq;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringsWithOperators();

            Console.ReadLine();
        }
        static void QueryStringsWithOperators()
        {
            Console.WriteLine("***** Using query operators *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = from game in currentVideoGames where game.Contains(" ") orderby game select game;

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
    }
}
