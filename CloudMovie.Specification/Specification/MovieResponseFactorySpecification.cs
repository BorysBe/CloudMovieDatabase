using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using MainService.Contracts;
using MainService.Factory;
using MainService.Model;
using NSubstitute;
using TddXt.AnyRoot;
using Xunit;
using Xunit.Abstractions;

namespace CloudMovie.Specification.Specification
{
    using static Root;

    public class MovieResponseFactorySpecification
    {
        public readonly TestBase Fixture;

        public MovieResponseFactorySpecification(ITestOutputHelper testOutputHelper)
        {
            Fixture = new TestBase(testOutputHelper);
        }

        [Fact]
        public void Create_new_movie_response()
        {
            // Arrange
            var movieRepository = Substitute.For<IMovieRepository>();
            var factory = new MovieResponseFactory(movieRepository);
            var movie = Any.Instance<Movie>();

            // Act
            factory.New(movie);

            // Assert
            movieRepository.Received(1).Create(movie);
        }

        [Fact]
        public void Create_all_movies_response()
        {
            // Arrange
            var movieRepository = Substitute.For<IMovieRepository>();
            var factory = new MovieResponseFactory(movieRepository);

            // Act
            factory.AllMovies();

            // Assert
            movieRepository.Received(1).RetrieveAll();
        }

        [Fact]
        public void Create_updated_movie_response()
        {
            // Arrange
            var movieRepository = Substitute.For<IMovieRepository>();
            var factory = new MovieResponseFactory(movieRepository);

            // Act
            Movie movie = Any.Instance<Movie>();
            factory.Update(movie);

            // Assert
            movieRepository.Received(1).Update(movie);
        }


        [Fact]
        public void Create_deleted_movie_response()
        {
            // Arrange
            var movieRepository = Substitute.For<IMovieRepository>();
            var movies = Any.Instance<List<Movie>>();
            movieRepository.RetrieveAll().Returns(movies);
            var factory = new MovieResponseFactory(movieRepository);
            var someMovie = movies.First();
            string title = someMovie.Title;
            movieRepository.Delete(title).Returns(someMovie);

            // Act
            var deleted = factory.Delete(title);

            // Assert
            movieRepository.Received(1).Delete(title);
            deleted.Should().Be(someMovie);
        }

        [Fact]
        public void Create_movie_response()
        {
            // Arrange
            var movieRepository = Substitute.For<IMovieRepository>();
            var movies = Any.Instance<List<Movie>>();
            movieRepository.RetrieveAll().Returns(movies);
            var factory = new MovieResponseFactory(movieRepository);
            var someMovie = movies.First();
            string title = someMovie.Title;
            movieRepository.RetrieveAll().Returns(movies);

            // Act
            var returned = factory.Get(title);

            // Assert
            movieRepository.Received(1).RetrieveAll();
            returned.Should().Be(someMovie);
        }

        [Fact]
        public void Create_movies_for_actor_response()
        {
            // Arrange
            var movieRepository = Substitute.For<IMovieRepository>();
            var movies = Any.Instance<List<Movie>>();
            movieRepository.RetrieveAll().Returns(movies);
            var factory = new MovieResponseFactory(movieRepository);
            var someMovie = movies.First();
            var actors = Any.Instance<List<Actor>>();
            someMovie.Starring.AddRange(actors);

            string firstName = someMovie.Starring.First().FirstName;
            string lastName = someMovie.Starring.First().LastName;
            movieRepository.RetrieveAll().Returns(movies);

            // Act
            var returned = factory.MoviesFor(firstName, lastName);

            // Assert
            movieRepository.Received(1).RetrieveAll();
            returned.Should().Contain(someMovie);
        }
    }
}