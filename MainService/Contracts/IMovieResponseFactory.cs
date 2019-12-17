using System.Collections.Generic;
using MainService.Model;

namespace MainService.Contracts
{
    public interface IMovieResponseFactory
    {
        List<Movie> AllMovies();
        Movie New(Movie movie);
        Movie Updated(Movie movie);
        Movie Deleted(string title);
        Movie WithActorFor(string title);
        List<Movie> MoviesFor(string firstName, string lastName);
        Movie Get(string title);
    }
}
