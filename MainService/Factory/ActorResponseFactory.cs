using System.Collections.Generic;
using MainService.Contracts;
using MainService.Model;

namespace MainService.Factory
{
    class ActorResponseFactory : IActorResponseFactory
    {
        public Actor New(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public List<Actor> AllActorsFor(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}