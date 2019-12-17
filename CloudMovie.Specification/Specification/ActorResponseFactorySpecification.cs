using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using MainService.Contracts;
using MainService.Factory;
using MainService.Model;
using Newtonsoft.Json;
using NSubstitute;
using TddXt.AnyRoot;
using TddXt.AnyRoot.Collections;
using TddXt.AnyRoot.Strings;
using Xunit;
using Xunit.Abstractions;

namespace CloudMovie.Specification.Specification
{
    using static Root;

    public class ActorResponseFactorySpecification
    {
        public readonly TestBase Fixture;

        public ActorResponseFactorySpecification(ITestOutputHelper testOutputHelper)
        {
            Fixture = new TestBase(testOutputHelper);
        }

        [Fact]
        public void Create_all_actors_response()
        {
            // Arrange
            var actorRepository = Substitute.For<IActorRepository>();
            var movieRepository = Substitute.For<IMovieRepository>();
            var actors = Any.Instance<List<Actor>>();
            actorRepository.RetrieveAll().Returns(actors);
            var movies = Any.Instance<List<Movie>>();
            movieRepository.RetrieveAll().Returns(movies);
            movies.First().Starring.Add(actors[0]);
            movies.First().Starring.Add(actors[1]);

            var factory = new ActorResponseFactory(actorRepository, movieRepository);

            // Act
            var title = movies.First().Title;
            var result = factory.AllActorsFor(title);

            // Assert
            result.Should().BeOfType<List<Actor>>();
            result.Should().NotBeEmpty();
            actorRepository.Received(1).RetrieveAll();
            movieRepository.Received(1).RetrieveAll();
        }

        [Fact]
        public void Create_new_actor_response()
        {
            // Arrange
            var actorRepository = Substitute.For<IActorRepository>();
            var actor = Any.Instance<Actor>();
            actor.Id = 0;

            var newlyCreatedActor = Any.Instance<Actor>();
            newlyCreatedActor.Id = (int)Any.Instance<uint>();

            actorRepository.Create(actor).Returns(newlyCreatedActor);
            var movieRepository = Substitute.For<IMovieRepository>();
            var factory = new ActorResponseFactory(actorRepository, movieRepository);

            // Act
            var result = factory.New(actor);

            // Assert
            result.Should().BeOfType<Actor>();
            result.Id.Should().NotBe(0);
        }
    }
}