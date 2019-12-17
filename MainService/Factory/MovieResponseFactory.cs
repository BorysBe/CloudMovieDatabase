using System.Collections.Generic;
using System.Linq;
using MainService.Contracts;
using MainService.Model;

namespace MainService.Factory
{
    public class MovieResponseFactory : IMovieResponseFactory
    {
        private readonly IMovieRepository _movieRepository;

        public MovieResponseFactory(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> AllMovies()
        {
            return _movieRepository.RetrieveAll().ToList();
        }

        public Movie New(Movie movie)
        {
            return _movieRepository.Create(movie);
        }

        public Movie Updated(Movie movie)
        {
            return _movieRepository.Update(movie);
        }

        public Movie Delete(string title)
        {
            return _movieRepository.Delete(title);
        }

        public List<Movie> MoviesFor(string firstName, string lastName)
        {
            return _movieRepository
                .RetrieveAll()
                .Where(x => x.Starring.Any(a => a.FirstName == firstName && a.LastName == lastName))
                .ToList();
        }

        public Movie Get(string title)
        {
            return _movieRepository
                .RetrieveAll()
                .FirstOrDefault(x => x.Title == title);
        }
    }
}