using System.Collections.Generic;
using MainService.Contracts;
using MainService.Model;
using TddXt.AnyRoot;

namespace CloudMovie.Specification.Factory
{
    using static Root;

    public class SpecificationMovieResponseFactory : IMovieResponseFactory
    {
        public List<Movie> AllMovies()
        {
            return Any.Instance<List<Movie>>();
        }

        public Movie New(Movie movie)
        {
            return movie;
        }

        public Movie Update(Movie movie)
        {
            return movie;
        }

        public Movie Delete(string title)
        {
            return Any.Instance<Movie>();
        }

        public List<Movie> MoviesFor(string firstName, string lastName)
        {
            return Any.Instance<List<Movie>>();
        }

        public Movie Get(string title)
        {
            return Any.Instance<Movie>();
        }
    }
}