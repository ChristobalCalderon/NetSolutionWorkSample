using Microsoft.AspNetCore.Mvc;
using NetSolutionWorkSample.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace NetSolutionWorkSample.Services
{
    public class TheMovieRepository : ITheMovieRepository
    {

        public async Task<MoviePage> TopRatedMovies(int page)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Movie.Base_Uri);
                var response = await client.GetAsync(Movie.TopRated_Uri + page);
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawMovie = JsonConvert.DeserializeObject<MoviePage>(stringResult);
                return rawMovie;
            }
        }

        public async Task<MoviePage> SearchMovieByName(string searchName)
        {
            using (var client = new HttpClient())
            {
                    client.BaseAddress = new Uri(Movie.Base_Uri);
                    var searchNameEncoded = HttpUtility.UrlEncode(searchName);
                    var response = await client.GetAsync(Movie.Search_Movie_Uri(searchNameEncoded));
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawMovie = JsonConvert.DeserializeObject<MoviePage>(stringResult);
                    return rawMovie;
            }
        }
    }
}
