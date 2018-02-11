using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSolutionWorkSample.Entity
{
    public class Movie
    {
        public const string Base_Uri = "https://api.themoviedb.org";
        public const string TopRated_Uri = "/3/movie/top_rated?api_key=717ee0dbdfafcfa5db97d570bcaa6a6c&language=en-US&page=";
        public const string Popular_Uri = "/3/movie/popular?api_key=717ee0dbdfafcfa5db97d570bcaa6a6c&language=en-US&page=";
        public const string Upcoming_Uri = "/3/movie/upcoming?api_key=717ee0dbdfafcfa5db97d570bcaa6a6c&language=en-US&page=1";
        //public int Vote_Count { get; set; }
        public int ID { get; set; }
        //public bool Video { get; set; }
        //public int Vote_Average { get; set; }
        public string Title { get; set; }
        //public double Popularity { get; set; }
        //public string Poster_path { get; set; }
        //public string Original_Language { get; set; }
        //public string Original_Title { get; set; }
        //public string Backdrop_path { get; set; }
        //public string Adult { get; set; }
        public string Overview { get; set; }
        //public DateTime Release_Date { get; set; }

        public static string Search_Movie_Uri(string searchName)
        {
            return $"https://api.themoviedb.org/3/search/movie?api_key=717ee0dbdfafcfa5db97d570bcaa6a6c&language=en-US&query={searchName}&page=1&include_adult=false";
        }
    }
}
