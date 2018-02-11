using Microsoft.AspNetCore.Mvc;
using NetSolutionWorkSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSolutionWorkSample.Controllers.api
{
    [Route("api/[controller]")]
    public class MovieController : BaseApiController
    {
        protected readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("GetRatedMoviesAsync/{page}")]
        public async Task<IActionResult> GetRatedMoviesAsync(int page)
        {
            return await CreateResponse(_movieService.GetRatedMoviesAsync(page));
        }

        [HttpGet]
        [Route("GetPopularMoviesAsync/{page}")]
        public async Task<IActionResult> GetPopularMoviesAsync(int page)
        {
            return await CreateResponse(_movieService.GetPopularMoviesAsync(page));
        }

        [HttpGet]
        [Route("GetUpcomingMoviesAsync/{page}")]
        public async Task<IActionResult> GetUpcomingMoviesAsync(int page)
        {
            return await CreateResponse(_movieService.GetUpcomingMoviesAsync(page));
        }

        [HttpGet]
        [Route("GetMovieAsync/{id}")]
        public async Task<IActionResult> GetMovieAsync(int id)
        {
            return await CreateResponse(_movieService.GetMovieAsync(id));
        }

        [HttpGet]
        [Route("GetSearchQueryStringAsync/{searchName}")]
        public async Task<IActionResult> GetSearchQueryStringAsync(string searchName)
        {
            return await CreateResponse(_movieService.GetSearchQueryStringAsync(searchName));
        }
    }
}
