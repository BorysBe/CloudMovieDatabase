using System.Collections.Generic;
using MainService.Model;

namespace MainService.Contracts
{
    public interface IMovieRepository
    {
        Movie Create(Movie actor);
        IEnumerable<Movie> RetrieveAll();
        Movie Update(Movie movie);
        Movie Delete(string title);
    }
}