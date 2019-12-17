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
    }
}