using NetSolutionWorkSample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSolutionWorkSample.Services
{
    public interface ITheMovieService
    {
        Task<MoviePage> GetRatedMoviesAsync(int page);
        Task<MoviePage> GetPopularMoviesAsync(int page);
        Task<MoviePage> GetUpcomingMoviesAsync(int page);
        Task<MoviePage> GetSearchQueryStringAsync(string searchName);   
    }
}
