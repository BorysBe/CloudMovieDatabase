using System.Collections.Generic;
using System.Dynamic;
using MainService.Model;

namespace MainService.Contracts
{
    public interface IActorResponseFactory
    {
        Actor New(Actor actor);
        List<Actor> AllActorsFor(string title);
    }
}