using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetSolutionWorkSample.Models;
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
            return await clientResponse(_theMovieService.GetRatedMoviesAsync(page));
        }

        public async Task<IActionResult> GetPopularMoviesAsync(int page)
        {
            return await clientResponse(_theMovieService.GetPopularMoviesAsync(page));
        }

        public async Task<IActionResult> GetUpcomingMoviesAsync(int page)
        {
            return await clientResponse(_theMovieService.GetUpcomingMoviesAsync(page));
        }

        public async Task<IActionResult> GetSearchQueryStringAsync(string searchName)
        {
            return await clientResponse(_theMovieService.GetSearchQueryStringAsync(searchName));
        }

        private async Task<IActionResult> clientResponse(Task<MoviePage> client)
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
