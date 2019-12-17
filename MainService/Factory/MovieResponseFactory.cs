using System.Collections.Generic;
using MainService.Contracts;
using MainService.Model;

namespace MainService.Factory
{
    class MovieResponseFactory : IMovieResponseFactory
    {
        public List<Movie> AllMovies()
        {
            throw new System.NotImplementedException();
        }

        public Movie New(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Movie Updated(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Movie Deleted(string title)
        {
            throw new System.NotImplementedException();
        }

        public Movie WithActorFor(string title)
        {
            throw new System.NotImplementedException();
        }

        public List<Movie> MoviesFor(string firstName, string lastName)
        {
            throw new System.NotImplementedException();
        }

        public Movie Get(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}