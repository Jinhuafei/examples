using PopularMovies.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PopularMovies.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
    }
}