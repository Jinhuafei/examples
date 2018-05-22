using System;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using PopularMovies.Bizlogic;
using PopularMovies.Repository;
using Unity;

namespace PopularMovies
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = this.AddUnity();

            container.RegisterType<IPopularMovie, MovieManager>();
            container.RegisterType<IMovieRepository, XmlMovieRepository>();
        }
    }
}