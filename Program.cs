using System;
using System.Linq;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main()
        {
            QueryStringsWithOperators();
            QueryStringsWithEnumerableAndLambdas();
            QueryStringsWithEnumerableAndLambdas2();
            QueryStringsWithAnonymousMethods();
            VeryComplexQueryExpression.QueryStringsWithRawDelegates();

            Console.ReadLine();
        }
        static void QueryStringsWithOperators()
        {
            Console.WriteLine("***** Using query operators *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = from game in currentVideoGames where game.Contains(" ") orderby game select game;

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
            Console.WriteLine();
        }
        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build a query expression using extension methods granted to the Array via the Enumerable type.
            var subset = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);

            // Print out the results
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
        static void QueryStringsWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Break it down!
            var gamesWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
            var orderedGames = gamesWithSpaces.OrderBy(game => game);
            var subset = orderedGames.Select(game => game);

            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build the necessary local functions.
            bool searchFilter(string game) { return game.Contains(" "); }
            string itemToProcess(string s) { return s; }

            // Pass the functions into the methods of Enumerable.
            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
    }
}
