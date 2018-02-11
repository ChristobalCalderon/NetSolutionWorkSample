using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using NetSolutionWorkSample.Entity;
using System.Web;
using NetSolutionWorkSample.Services;
using NetSolutionWorkSample.Entities;

namespace NetSolutionWorkSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITheMovieService _theMovieService;
        public HomeController(ITheMovieService theMovieService)
        {
            _theMovieService = theMovieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetRatedMoviesAsync(int page)
        {
            return await HttpRequest(_theMovieService.GetRatedMoviesAsync(page));
        }

        public async Task<IActionResult> GetPopularMoviesAsync(int page)
        {
            return await HttpRequest(_theMovieService.GetPopularMoviesAsync(page));
        }

        public async Task<IActionResult> GetUpcomingMoviesAsync(int page)
        {
            return await HttpRequest(_theMovieService.GetUpcomingMoviesAsync(page));
        }

        public async Task<IActionResult> GetMovieAsync(int id)
        {
            return await HttpRequest(_theMovieService.GetMovieAsync(id));
        }

        public async Task<IActionResult> GetSearchQueryStringAsync(string searchName)
        {
            return await HttpRequest(_theMovieService.GetSearchQueryStringAsync(searchName));
        }

        private async Task<IActionResult> HttpRequest(Task<MoviePage> client)
        {
            try
            {
                return Ok(await client);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting movies from Themoviedb: {httpRequestException.Message}");
            }
        }

        private async Task<IActionResult> HttpRequest(Task<Movie> client)
        {
            try
            {
                return Ok(await client);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting movies from Themoviedb: {httpRequestException.Message}");
            }
        }
    }
}
