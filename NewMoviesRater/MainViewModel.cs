using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MoviesService;

namespace NewMoviesRater
{
    public class MainViewModel
    {
        private string _moviesServiceAddress;

        public MainViewModel()
        {
            _moviesServiceAddress = ConfigurationManager.AppSettings.GetValues("MoviesServiceAddress")?[0];

            Movies = new ObservableCollection<Movie>();

            Task.Run(() =>
            {
                while (true)
                {
                    Task.Run(async () => await LoadMoviesStreamAsync());
                    Thread.Sleep(10000);
                }
            });
        }

        public ObservableCollection<Movie> Movies { get; set; }

        public Movie SelectedMovie { get; set; }

        private async Task LoadMoviesStreamAsync()
        {
            using (var channel = GrpcChannel.ForAddress(_moviesServiceAddress))
            {
                var moviesClient = new Movies.MoviesClient(channel);
                using (var call = moviesClient.GetMoviesStream(new Empty()))
                {
                    while (await call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                        var movie = call.ResponseStream.Current;

                        if (!Movies.Contains(movie))
                        {
                            //Movies.Add(movie);
                            await Application.Current.Dispatcher.InvokeAsync(() => Movies.Add(movie));
                            //await Application.Current.Dispatcher.InvokeAsync(() => OnPropertyChanged(nameof(Movies)));
                        }
                    }
                }
            }
        }
    }
}
