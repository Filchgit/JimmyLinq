using System;
using System.Collections.Generic;
using System.Linq;

namespace JimmyLinq
{
    public static class ComicAnalyser
    {
         public static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal>prices)
        {
            if (prices[comic.IssueNumber] < 100M)
                return PriceRange.Cheap;
            else
                return PriceRange.Expensive;
        }

         public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            /*var grouped =                                                 // IEnumerable<IGrouping<PriceRange, Comic>>grouped works the same as var grouped 
               from comic in comics
               orderby prices[comic.IssueNumber]
                group comic by CalculatePriceRange(comic, prices) into priceGroup
               select priceGroup;
             return grouped;*/

            var grouped = comics.OrderBy(comic => prices[comic.IssueNumber]).GroupBy(comic => CalculatePriceRange(comic, prices));    
                   //ok so this passes my test  so I know it is a correct refactor of the above Linq query
            return grouped;
        }

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            /*var joined =
                from comic in comics
                orderby comic.IssueNumber
                join review in reviews on comic.IssueNumber equals review.Issue
                select $"{review.Critic} rated #{comic.IssueNumber} '{comic.Name}' {review.Score:0.00}";
            return joined;*/

            var joined2 = comics.OrderBy(comic => comic.IssueNumber).Join(reviews, comic => comic.IssueNumber, review => review.Issue, (comic, review) => $"{review.Critic} rated #{comic.IssueNumber} '{comic.Name}' {review.Score:0.00}");
            return joined2;   
            //OMG this one works too, I am so going to have to always go back and refer to this!!! So happy I sussed this out.
        }
    }
}