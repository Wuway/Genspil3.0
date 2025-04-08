using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil3._0
{
    internal class Search
    {
        public static void ShowSearchRequestResults()
        {
            Console.WriteLine("Indtast søgekriterier for forespørgsler:");
            string criteria = Console.ReadLine();

            // Eksempel på søgning i en liste af forespørgsler  
            List<Request> matchingRequests = Request.GetAllRequests()
                .Where(r => r.MatchesCriteria(criteria))
                .ToList();

            if (matchingRequests.Count > 0)
            {
                Console.WriteLine("Følgende forespørgsler matcher dine kriterier:");
                foreach (var request in matchingRequests)
                {
                    Console.WriteLine(request.ToString());
                }
            }
            else
            {
                Console.WriteLine("Ingen forespørgsler matcher dine kriterier.");
            }
        }

        internal static void ShowSearchGameResults()
        {
            throw new NotImplementedException();
        }
    }
}