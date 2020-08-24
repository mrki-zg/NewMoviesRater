using System.Collections.Generic;

namespace MoviesService.Util
{
    public interface IStorage<T>
    {
        void Add(T obj);

        IList<T> Get(int howMany);
    }
}
