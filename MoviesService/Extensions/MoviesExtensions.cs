namespace MoviesService.Extensions
{
    public static class MoviesExtensions
    {
        public static Models.Movie ToModelType(this Movie movie)
        {
            return new Models.Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year
            };
        }

        public static Movie ToServiceType(this Models.Movie movie)
        {
            return new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year
            };
        }
    }
}
