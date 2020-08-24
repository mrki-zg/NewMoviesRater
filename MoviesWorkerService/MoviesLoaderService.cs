using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace MoviesWorkerService
{
    public class MoviesLoaderService : IHostedService, IDisposable
    {
        private const int LoadLimit = 20;
        private const int MaxMoviesLimit = 9916880;

        private readonly ILogger<MoviesLoaderService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private Timer _timer;
        private string _apiKey;

        public MoviesLoaderService(ILogger<MoviesLoaderService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;

            _apiKey = configuration["AppSettings:OMDbApiKey"];
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Movies Worker Service started.");

            _timer = new Timer(LoadMovies, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Movies Worker Service stopped.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void LoadMovies(object state)
        {
            _logger.LogInformation("Loading movies...");

            var client = _httpClientFactory.CreateClient();

            var now = DateTime.Now;
            var randomGen = new Random(now.Hour + now.Minute + now.Second);
            for (int i = 0; i < LoadLimit; i++)
            {
                var id = randomGen.Next(1, MaxMoviesLimit);
                var url = $"http://www.omdbapi.com/?i=tt{id:0000000}&apikey={_apiKey}";

                var response = client.GetAsync(url).ConfigureAwait(false).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Could not load information for movie with id = {0}, status code = {1}",
                        id.ToString("0000000"), response.StatusCode);
                    continue;
                }

                var result = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var jsonObj = JObject.Parse(result);

                if (jsonObj["Type"]?.ToString() == "movie")
                {
                    //TODO
                    _logger.LogInformation(result);
                }
            }

            _logger.LogInformation("Loaded movies.");
        }
    }
}
