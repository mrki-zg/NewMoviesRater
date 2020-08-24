using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace MoviesService.Services
{
    public class MoviesService : Movies.MoviesBase
    {
        private readonly ILogger<MoviesService> _logger;
        private readonly IMemoryCache _cache;

        public MoviesService(ILogger<MoviesService> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public override Task<Empty> UploadMovies(UploadMoviesRequest request, ServerCallContext context)
        {
            if (request != null && request.Movies != null)
            {
                _logger.LogInformation("Uploading {0} movies", request.Movies.Count);

                foreach (var requestMovie in request.Movies)
                {
                    // storing to memory cache instead of database
                    _cache.GetOrCreate(requestMovie.Title, entry =>
                    {
                        var value = Model.Movie.From(requestMovie);
                        entry.Value = value;

                        return value;
                    });
                }
            }

            return Task.FromResult(new Empty());
        }
    }
}
