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
            return await client(Movie.TopRated_Uri + page);
        }

        public async Task<MoviePage> PopularMovies(int page)
        {
            return await client(Movie.Popular_Uri + page);
        }

        public async Task<MoviePage> UpcomingMovies(int page)
        {
            return await client(Movie.Upcoming_Uri + page);
        }

        public async Task<MoviePage> SearchMovieByName(string searchName)
        {
            return await client(Movie.Search_Movie_Uri(HttpUtility.UrlEncode(searchName)));
        }


        private static async Task<MoviePage> client(string clientUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Movie.Base_Uri);
                var response = await client.GetAsync(clientUri);
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawMovie = JsonConvert.DeserializeObject<MoviePage>(stringResult);
                return rawMovie;
            }
        }

    }
}
