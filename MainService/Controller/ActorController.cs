using System.Threading.Tasks;
using MainService.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    public class ActorController : ControllerBase
    {
        public ActorController()
        {
        }

        [HttpPost("Actor")]
        public Task<string> New(Actor actor)
        {
            return Task.FromResult("ok");
        }

        [HttpGet("Movie")]
        public Task<string> ActorsFor(string title)
        {
            return Task.FromResult("ok");
        }

        [HttpPut("Movie")]
        public Task<string> Update(string title, Actor actor)
        {
            return Task.FromResult("ok");
        }

    }
}