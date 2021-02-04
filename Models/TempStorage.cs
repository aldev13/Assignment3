//Temporary storage model that will keep track of each Movie entry, adding it to a list

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public static class TempStorage
    {
        private static List<MovieModel> entries = new List<MovieModel>();

        public static IEnumerable<MovieModel> Entires => entries;
       
        public static void AddEntry(MovieModel entry)
        {
            //Checks if entry is the Movie Independence Day and excludes it from storage per preference

            if (entry.Title == "Independence Day")
            {

            }
            else
            { 
            entries.Add(entry);
            }
        }
    }
}
