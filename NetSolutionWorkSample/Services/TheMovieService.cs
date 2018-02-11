using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetSolutionWorkSample.Entities;
using NetSolutionWorkSample.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace NetSolutionWorkSample.Services
{
    public class TheMovieService : ITheMovieService
    {
        private readonly IOptions<TheMovieDBServiceSettings> _serviceSettings;
        public TheMovieService(IOptions<TheMovieDBServiceSettings> serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }
        public async Task<MoviePage> GetRatedMoviesAsync(int page)
        {
            return await Movies(composeUrl(_serviceSettings.Value.TopRated_Uri, page));
        }

        public async Task<MoviePage> GetPopularMoviesAsync(int page)
        {
            return await Movies(composeUrl(_serviceSettings.Value.Popular_Uri, page));
        }

        public async Task<MoviePage> GetUpcomingMoviesAsync(int page)
        {
            return await Movies(composeUrl(_serviceSettings.Value.Upcoming_Uri, page));
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await Movie(composeMovieUrl(_serviceSettings.Value.Movie_Details_Uri, id));
        }

        public async Task<MoviePage> GetSearchQueryStringAsync(string searchName)
        {
            return await Movies(composeSearchQueryUrl(_serviceSettings.Value.Search_Movie_Uri, 1, searchName, _serviceSettings.Value.Search_Movie_Uri_End));
        }


        private async Task<MoviePage> Movies(string clientUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_serviceSettings.Value.BaseUri);
                var response = await client.GetAsync(clientUri);
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawMovies = JsonConvert.DeserializeObject<MoviePage>(stringResult);
                return rawMovies;
            }
        }

        private async Task<Movie> Movie(string clientUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_serviceSettings.Value.BaseUri);
                var response = await client.GetAsync(clientUri);
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawMovie = JsonConvert.DeserializeObject<Movie>(stringResult);
                return rawMovie;
            }
        }

        public string composeUrl(string url, int page)
        {
            return url + "?api_key=" + _serviceSettings.Value.ApiKey + "&language=en-US&page=" + page;
        }

        public string composeMovieUrl(string url, int page)
        {
            return url + page + "?api_key=" + _serviceSettings.Value.ApiKey + "&language=en-US";
        }

        public string composeSearchQueryUrl(string url, int page = 1, string searchQuery = null, string urlEnd = null)
        {
            return url + "?api_key=" + _serviceSettings.Value.ApiKey + "&language=en-US" + (searchQuery != null ? "&query=" + HttpUtility.UrlEncode(searchQuery) : "") + "&page=" + page + urlEnd;
        }
    }
}
