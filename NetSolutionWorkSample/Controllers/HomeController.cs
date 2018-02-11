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

namespace NetSolutionWorkSample.Controllers
{
    public class HomeController : Controller
    {
        ITheMovieRepository _theMovieRepository;
        public HomeController(ITheMovieRepository theMovieRepository)
        {
            _theMovieRepository = theMovieRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TopRatedMovies(int page)
        {
            return await clientRepsone(_theMovieRepository.TopRatedMovies(page));
        }

        public async Task<IActionResult> PopularMovies(int page)
        {
            return await clientRepsone(_theMovieRepository.PopularMovies(page));
        }

        public async Task<IActionResult> UpcomingMovies(int page)
        {
            return await clientRepsone(_theMovieRepository.UpcomingMovies(page));
        }

        public async Task<IActionResult> SearchMovieByName(string searchName)
        {
            return await clientRepsone(_theMovieRepository.SearchMovieByName(searchName));
        }

        private async Task<IActionResult> clientRepsone(Task<MoviePage> client)
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
