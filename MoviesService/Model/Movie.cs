using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesService.Model
{
    public class Movie
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public static Movie From(MoviesService.Movie other)
        {
            return new Movie
            {
                Title = other.Title,
                Description = other.Description,
                Year = other.Year
            };
        }
    }
}
