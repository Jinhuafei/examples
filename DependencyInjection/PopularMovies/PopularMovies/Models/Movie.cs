using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopularMovies.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Directors { get; set; }

        public string Genres { get; set; }

        public double PopularIndex { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}