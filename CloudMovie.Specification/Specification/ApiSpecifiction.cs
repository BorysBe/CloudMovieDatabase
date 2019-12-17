using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssertions;
using MainService.Model;
using Newtonsoft.Json;
using TddXt.AnyRoot;
using TddXt.AnyRoot.Strings;
using TddXt.AnyRoot.Time;
using Xunit;
using Xunit.Abstractions;

namespace CloudMovie.Specification.Specification
{
    using static Root;

    public partial class ApiSpecification
    {
        public readonly TestBase Fixture;

        public ApiSpecification(ITestOutputHelper testOutputHelper)
        {
            Fixture = new TestBase(testOutputHelper);
        }

        [Fact]
        public async void Add_new_movie_to_the_system()
        {
            // Arrange
            var url = "/api/Movie/Movie";
            var movie = Any.Instance<Movie>();
            string jsonString = JsonConvert.SerializeObject(movie);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PostAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<Movie>(out var createdMovie);
        }

        [Fact]
        public async void Add_new_actor()
        {
            // Arrange
            var url = "/api/Actor/Actor";
            var actor = Any.Instance<Actor>();
            string jsonString = JsonConvert.SerializeObject(actor);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PostAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<Actor>(out var createdActor);
        }

        [Fact]
        public async void Link_existing_actor_to_existing_movie()
        {
            // Arrange
            var url = "/api/Movie/Actor?title=" + Any.String();
            var actor = Any.Instance<Actor>();
            string jsonString = JsonConvert.SerializeObject(actor);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PutAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<Movie>(out var updatedMovie);
        }

        [Fact]
        public async void Update_information_about_existing_movie()
        {
            // Arrange
            var url = "/api/Movie/Movie?title=" + Any.String();
            var movieForUpdate = Any.Instance<Movie>();
            string jsonString = JsonConvert.SerializeObject(movieForUpdate);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PutAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<Movie>(out var updatedMovie);
        }

        [Fact]
        public async void Delete_existing_movie()
        {
            // Arrange
            var title = Any.Instance<Movie>().Title;
            var url = $"/api/Movie/Movie?title={title}";

            // Act
            var response = await Fixture.Client.DeleteAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<Movie>(out var removedMovie);
        }

        [Fact]
        public async void List_movies_all()
        {
            // Arrange
            var url = "/api/Movie/Movie";

            // Act
            var response = await Fixture.Client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<List<Movie>>(out var allMovies);
        }

        [Fact]
        public async void List_movies_by_year()
        {
            // Arrange
            var url = "/api/Movie/Movie?year=" + Any.DateTime().ToString("yyyy");

            // Act
            var response = await Fixture.Client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<List<Movie>>(out var allMovies);
        }

        [Fact]
        public async void List_actors_starring_in_a_movie()
        {
            // Arrange
            var url = "/api/Actor/Movie?title=" + Any.String();

            // Act
            var response = await Fixture.Client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<List<Actor>>(out var allMovieActors);
        }

        [Fact]
        public async void List_movies_with_given_actor()
        {
            // Arrange
            var url = "/api/Movie/Actor?firstName=" + Any.String() + "&lastName" + Any.String();

            // Act
            var response = await Fixture.Client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            responseJson.Should().BeDeserializedTo<List<Movie>>(out var allMovies);
        }

        [Fact]
        public async void Cannot_add_new_movie_without_actors()
        {
            // Arrange
            var url = "/api/Movie/Movie";
            var movie = Any.Instance<Movie>();
            movie.SetNoActors();
            string jsonString = JsonConvert.SerializeObject(movie);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PostAsync(url, httpContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Movies_year_cannot_be_a_future_year()
        {
            // Arrange
            var url = "/api/Movie/Movie";
            var movie = Any.Instance<Movie>();
            movie.Year = SetFutureDate();
            movie.Starring.Add(Any.Instance<Actor>());
            string jsonString = JsonConvert.SerializeObject(movie);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PostAsync(url, httpContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private static int SetFutureDate()
        {
            return DateTime.Now.AddYears(1).Year;
        }

        [Fact]
        public async void Actors_first_name_cannot_be_empty()
        {
            // Arrange
            var url = "/api/Actor/Actor";
            var actor = Any.Instance<Actor>();
            actor.FirstName = SetEmptyName();
            string jsonString = JsonConvert.SerializeObject(actor);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PostAsync(url, httpContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Actors_last_name_cannot_be_empty()
        {
            // Arrange
            var url = "/api/Actor/Actor";
            var actor = Any.Instance<Actor>();
            actor.LastName = SetEmptyName();
            string jsonString = JsonConvert.SerializeObject(actor);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await Fixture.Client.PostAsync(url, httpContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private string SetEmptyName()
        {
            return string.Empty;
        }
    }
}

