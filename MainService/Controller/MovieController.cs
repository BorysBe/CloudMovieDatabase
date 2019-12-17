using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainService.Contracts;
using MainService.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    public class MovieController : ControllerBase
    {
        private readonly IMovieResponseFactory _movieResponseFactory;

        public MovieController(IMovieResponseFactory movieResponseFactory)
        {
            _movieResponseFactory = movieResponseFactory;
        }

        [HttpGet("Movie")]
        public Task<List<Movie>> All()
        {
            return Task.FromResult(_movieResponseFactory.AllMovies());
        }

        [HttpPost("Movie")]
        public Task<Movie> New(Movie movie)
        {
            if (!movie.Starring.Any() || movie.Year > DateTime.Now.Year)
            {
                Response.StatusCode = 400;
                Task.FromResult(movie);
            }

            return Task.FromResult(_movieResponseFactory.New(movie));
        }

        [HttpPut("Movie")]
        public Task<Movie> Update(Movie movie)
        {
            return Task.FromResult(_movieResponseFactory.Update(movie));
        }
        
        [HttpDelete("Movie")]
        public Task<Movie> Delete(string title)
        {
            return Task.FromResult(_movieResponseFactory.Delete(title));
        }

        [HttpGet("Actor")]
        public Task<List<Movie>> MovieFor(string firstName, string lastName)
        {
            return Task.FromResult(_movieResponseFactory.MoviesFor(firstName, lastName));
        }

        [HttpPut("Actor")]
        public Task<Movie> Update(string title, Actor actor)
        {
            var movie = _movieResponseFactory.Get(title);
            movie.Add(actor);
            return Task.FromResult(_movieResponseFactory.Update(movie));
        }
    }
}
