using PopularMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PopularMovies.Bizlogic
{
    public interface IPopularMovie
    {
        Task<IEnumerable<Movie>> GetPopularMoviesAsync();
    }
}