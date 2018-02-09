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
            try
            {
                return Ok(await _theMovieRepository.TopRatedMovies(page));
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting movies from Themoviedb: {httpRequestException.Message}");
            }
        }

        public async Task<IActionResult> SearchMovieByName(string searchName)
        {
            try
            {
                return Ok(await _theMovieRepository.SearchMovieByName(searchName));
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting movie from Themoviedb: {httpRequestException.Message}");
            }
        }
    }
}
