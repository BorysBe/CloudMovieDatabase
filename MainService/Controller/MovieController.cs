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

        [HttpGet("Test")]
        public Task<string> Test()
        {
            return Task.FromResult("ok");
        }

        [HttpPut("New")]
        public Task<string> New(Movie movie)
        {
            return Task.FromResult("ok");
        }
    }
}
