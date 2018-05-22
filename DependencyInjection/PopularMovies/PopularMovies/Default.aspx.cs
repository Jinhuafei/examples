using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PopularMovies.Bizlogic;
using PopularMovies.Repository;

namespace PopularMovies
{
    public partial class Default : System.Web.UI.Page
    {
        private IPopularMovie movieMgr;
        public Default(IPopularMovie movieManager)
        {
            movieMgr = movieManager;
        }

        public async Task<SelectResult> movieList_GetData()
        {
            var movies = await movieMgr.GetPopularMoviesAsync();
            return new SelectResult(movies.Count(), movies);
        }
    }
}