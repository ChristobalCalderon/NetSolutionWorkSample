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
    public class MovieService : HttpBaseService, IMovieService
    {
        private readonly IOptions<MovieServiceSettings> _serviceSettings;
        public MovieService(IOptions<MovieServiceSettings> serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }
        public async Task<MoviePage> GetRatedMoviesAsync(int page)
        {
            return await FetchMoviesAsync(composeUrl(_serviceSettings.Value.TopRated_Uri, page));
        }

        public async Task<MoviePage> GetPopularMoviesAsync(int page)
        {
            return await FetchMoviesAsync(composeUrl(_serviceSettings.Value.Popular_Uri, page));
        }

        public async Task<MoviePage> GetUpcomingMoviesAsync(int page)
        {
            return await FetchMoviesAsync(composeUrl(_serviceSettings.Value.Upcoming_Uri, page));
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await FetchMovieAsync(composeMovieUrl(_serviceSettings.Value.Movie_Details_Uri, id));
        }

        public async Task<MoviePage> GetSearchQueryStringAsync(string searchName)
        {
            return await FetchMoviesAsync(composeSearchQueryUrl(_serviceSettings.Value.Search_Movie_Uri, 1, searchName, _serviceSettings.Value.Search_Movie_Uri_End));
        }

        private string composeUrl(string url, int page)
        {
            return url + "?api_key=" + _serviceSettings.Value.ApiKey + "&language=en-US&page=" + page;
        }

        private string composeMovieUrl(string url, int page)
        {
            return url + page + "?api_key=" + _serviceSettings.Value.ApiKey + "&language=en-US";
        }

        private string composeSearchQueryUrl(string url, int page = 1, string searchQuery = null, string urlEnd = null)
        {
            return url + "?api_key=" + _serviceSettings.Value.ApiKey + "&language=en-US" + (searchQuery != null ? "&query=" + HttpUtility.UrlEncode(searchQuery) : "") + "&page=" + page + urlEnd;
        }

        private async Task<MoviePage> FetchMoviesAsync(string requestUri)
        {
            return JsonConvert.DeserializeObject<MoviePage>(await GetHttpClientAsync(_serviceSettings.Value.BaseUri, requestUri));
        }

        private async Task<Movie> FetchMovieAsync(string requestUri)
        {
            return JsonConvert.DeserializeObject<Movie>(await GetHttpClientAsync(_serviceSettings.Value.BaseUri, requestUri));
        }
    }
}
