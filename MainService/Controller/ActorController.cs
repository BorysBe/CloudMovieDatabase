using System.Collections.Generic;
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
    public class ActorController : ControllerBase
    {
        private readonly IActorResponseFactory _actorResponseFactory;

        public ActorController(IActorResponseFactory actorResponseFactory)
        {
            _actorResponseFactory = actorResponseFactory;
        }

        [HttpPost("Actor")]
        public Task<Actor> New(Actor actor)
        {
            return Task.FromResult(_actorResponseFactory.New(actor));
        }

        [HttpGet("Movie")]
        public Task<List<Actor>> ActorsFor(string title)
        {
            return Task.FromResult(_actorResponseFactory.AllActorsFor(title));
        }
    }
}