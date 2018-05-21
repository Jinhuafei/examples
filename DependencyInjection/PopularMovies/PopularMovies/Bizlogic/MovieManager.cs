using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PopularMovies.Models;
using PopularMovies.Repository;

namespace PopularMovies.Bizlogic
{
    public class MovieManager : IPopularMovie
    {
        private const double PopularIndexBar = 9.0;

        private IMovieRepository movieRepo;

        public MovieManager(IMovieRepository repository)
        {
            movieRepo = repository;
        }

        public async Task<IEnumerable<Movie>> GetPopularMoviesAsync()
        {
            var allMovies = await movieRepo.GetAllMoviesAsync();
            return allMovies.Where(movie => movie.PopularIndex >= PopularIndexBar);
        }
    }
}