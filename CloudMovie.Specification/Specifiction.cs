using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using AutoFixture;
using FluentAssertions;
using MainService.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TddXt.AnyRoot;
using Xunit;
using Xunit.Abstractions;

namespace CloudMovie.Specification
{
    using static Root;

    public class Specification
    {
        public readonly TestBase Fixture;

        public Specification(ITestOutputHelper testOutputHelper)
        {
            Fixture = new TestBase(testOutputHelper);
        }

        [Fact]
        public async void Test()
        {
            // Arrange
            var url = "/api/Movie/Test";

            // Act
            var response = await Fixture.Client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
        }


        [Fact] public async void Add_new_movie_to_the_system() 
        {
            // Arrange
            var url = "/api/Movie/New";
            var movie = Any.Instance<Movie>();
            string jsonString = JsonConvert.SerializeObject(movie);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            // Act
            var response = await Fixture.Client.PutAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
        }

        [Fact] public void Add_new_actor() { Fail(); }
        [Fact] public void Link_existing_actor_to_existing_movie() { Fail(); }
        [Fact] public void Update_information_about_existing_movie() { Fail(); }
        [Fact] public void Delete_existing_movie() { Fail(); }
        [Fact] public void List_movies_all_and_by_year() { Fail(); }
        [Fact] public void List_actors_starring_in_a_movie() { Fail(); }
        [Fact] public void List_movies_with_given_actor() { Fail(); }
        [Fact] public void Cannot_add_new_movie_without_actors() { Fail(); }
        [Fact] public void Movies_year_cannot_be_a_future_year() { Fail(); }
        [Fact] public void Actors_first_and_last_name_cannot_be_empty() { Fail(); }
        
        private void Fail()
        {
            Assert.True(false, "Not finished test");
        }
    }
}

