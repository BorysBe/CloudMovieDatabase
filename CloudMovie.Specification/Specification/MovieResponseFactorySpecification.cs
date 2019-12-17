using MainService.Factory;
using Xunit;
using Xunit.Abstractions;

namespace CloudMovie.Specification.Specification
{
    public class MovieResponseFactorySpecification
    {
        public readonly TestBase Fixture;

        public MovieResponseFactorySpecification(ITestOutputHelper testOutputHelper)
        {
            Fixture = new TestBase(testOutputHelper);
        }

        [Fact]
        public void Create_all_movies_response()
        {
            // Arrange
            var factory = new MovieResponseFactory();

            // Act

            // Assert
        }
    }