using System;
using System.Collections.Generic;

namespace MoviesService.Util
{
    public class ListStorage : IStorage<Models.Movie>
    {
        private IList<Models.Movie> _movies;

        private object lockObj = new object();

        public ListStorage()
        {
            _movies = new List<Models.Movie>();
        }

        public void Add(Models.Movie obj)
        {
            lock (lockObj)
            {
                _movies.Add(obj);
            }
        }

        public IList<Models.Movie> Get(int howMany)
        {
            if (howMany < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(howMany));
            }

            IList<Models.Movie> result = new List<Models.Movie>();
            lock (lockObj)
            {
                var count = _movies.Count;
                var limit = howMany > count ? count : howMany;
                for (var i = 0; i < limit; i++)
                {
                    result.Add((Models.Movie) _movies[count - 1 - i].Clone());
                }
            }

            return result;
        }
    }
}
