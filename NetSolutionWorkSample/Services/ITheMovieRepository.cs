using NetSolutionWorkSample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSolutionWorkSample.Services
{
    public interface ITheMovieRepository
    {
        Task<MoviePage> TopRatedMovies(int page);

        Task<MoviePage> SearchMovieByName(string searchName);   
    }
}
