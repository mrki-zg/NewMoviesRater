using System;
using MoviesService.Extensions;

namespace MoviesService.Models
{
    public class Movie : ICloneable
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public object Clone()
        {
            return this.ToServiceType().ToModelType();
        }
    }
}
