using System.Threading.Tasks;
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
        public MovieController()
        {
        }

        [HttpGet("Movie")]
        public Task<string> All()
        {
            return Task.FromResult("ok");
        }

        [HttpPost("Movie")]
        public Task<string> New(Movie movie)
        {
            return Task.FromResult("ok");
        }

        [HttpPut("Movie")]
        public Task<string> Update(Movie movie)
        {
            return Task.FromResult("ok");
        }
        
        [HttpDelete("Movie")]
        public Task<string> Delete(string title)
        {
            return Task.FromResult("ok");
        }

        [HttpPut("Actor")]
        public Task<string> PutActor(Actor actor, string title)
        {
            return Task.FromResult("ok");
        }

        [HttpGet("Actor")]
        public Task<string> MovieFor(string firstName, string lastName)
        {
            return Task.FromResult("ok");
        }

    }
}
