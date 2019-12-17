using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using MainService.Factory;
using MainService.Model;
using Newtonsoft.Json;
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
        public async void Create_all_actors_response()
        {
            // Arrange
            var factory = new ActorResponseFactory();

            // Act
            var result = factory.AllActorsFor(Any.String());

            // Assert
            result.Should().BeOfType<List<Actor>>();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async void Create_new_actor_response()
        {
            // Arrange
            var factory = new ActorResponseFactory();

            // Act
            var result = factory.New(Any.Instance<Actor>());

            // Assert
            result.Should().BeOfType<Actor>();
            result.Id.Should().NotBe(0);
        }
    }
}