using System;


namespace JimmyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var done = false;
            while (!done)
            {
                Console.WriteLine("\nPress G to group comics by price, R to get reviews, any other key to quit \n");
                _ = Console.ReadKey(true).KeyChar.ToString().ToUpper() switch
                // the solution actually had this as done = Console.ReadKey(true).KeyChar.ToString().ToUpper() switch
                {
                    "G" => done = GroupComicsByPrice(),
                    "R" => done = GetReviews(),
                    _ => done = true,
                };
                // basically this is saying, if the ConsoleRead is a key character then execute the switch function similiar to what we had before
                // switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
                // {
                    /*case "G":
                        done = GroupComicsByPrice();
                        break;
                    case "R":
                        done = GetReviews();
                        break;
                    default:
                        done = true;
                        break;*/
                // };
            }
      
                
        }

        private static bool GroupComicsByPrice()
        {
            var groups = ComicAnalyser.GroupComicsByPrice(Comic.Catalog, Comic.Prices);
            foreach (var group in groups)
            {
                Console.WriteLine($"{ group.Key} GroupComicsByPrice:");
                foreach (var comic in group)
                {
                    Console.WriteLine($"#{comic.IssueNumber} {comic.Name}: {Comic.Prices[comic.IssueNumber]:c}");
                }
               
            }
            return false;
        }
        private static bool GetReviews()
        {
            var reviews = ComicAnalyser.GetReviews(Comic.Catalog, Comic.Reviews);
            foreach(var review in reviews)
            {
                Console.WriteLine(review);              
            }
            return false;
        }
    }
}
