using System.Collections.Generic;
using MainService.Model;

namespace MainService.Contracts
{
    public interface IMovieResponseFactory
    {
        List<Movie> AllMovies();
        Movie New(Movie movie);
        Movie Updated(Movie movie);
        Movie Delete(string title);
        List<Movie> MoviesFor(string firstName, string lastName);
        Movie Get(string title);
    }
}
