using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using MoviesService.Extensions;
using MoviesService.Util;

namespace MoviesService.Services
{
    public class MoviesService : Movies.MoviesBase
    {
        // WARNING: Azure App Service does not support gRPC => https://github.com/dotnet/AspNetCore/issues/9020

        private readonly ILogger<MoviesService> _logger;
        private readonly IStorage<Models.Movie> _cache;

        public MoviesService(ILogger<MoviesService> logger, IStorage<Models.Movie> cache)
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
                    _cache.Add(requestMovie.ToModelType());
                }
            }

            return Task.FromResult(new Empty());
        }

        public override async Task GetMoviesStream(Empty request, IServerStreamWriter<Movie> responseStream, ServerCallContext context)
        {
            var latest = _cache.Get(10);
            foreach (var movie in latest)
            {
                await responseStream.WriteAsync(movie.ToServiceType());
            }
        }
    }
}
