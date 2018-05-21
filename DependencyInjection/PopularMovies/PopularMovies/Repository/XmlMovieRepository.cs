using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using PopularMovies.Models;

namespace PopularMovies.Repository
{
    public class XmlMovieRepository : IMovieRepository
    {
        private const string MovieDataFileName = "MoviesData.xml";
        private static IEnumerable<Movie> allMovies;

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await LoadAllMovies();            
        }

        private static async Task<IEnumerable<Movie>> LoadAllMovies()
        {
            if(allMovies != null)
            {
                return allMovies;
            }

            var settings = new XmlReaderSettings() { Async = true };
            var dataFileLocation = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", MovieDataFileName);
            var movies = new List<Movie>();

            using (var reader = XmlReader.Create(dataFileLocation, settings))
            {
                Movie movie = null;
                while(await reader.ReadAsync())
                {
                    if(reader.NodeType == XmlNodeType.Element)
                    {
                        switch(reader.Name)
                        {
                            case "movie":
                                movie = new Movie();
                                break;
                            case "title":
                                await reader.ReadAsync();
                                movie.Title = reader.Value;
                                break;
                            case "id":
                                await reader.ReadAsync();
                                movie.Id = reader.Value;
                                break;
                            case "directors":
                                await reader.ReadAsync();
                                movie.Directors = reader.Value;
                                break;
                            case "genres":
                                await reader.ReadAsync();
                                movie.Genres = reader.Value;
                                break;
                            case "popularIndex":
                                await reader.ReadAsync();
                                movie.PopularIndex = double.Parse(reader.Value);
                                break;
                            case "releaseDate":
                                await reader.ReadAsync();
                                movie.ReleaseDate = DateTime.Parse(reader.Value);
                                break;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "movie")
                    {
                        movies.Add(movie);
                    }
                }                
            }
            allMovies = movies;
            return allMovies;
        }
    }
}