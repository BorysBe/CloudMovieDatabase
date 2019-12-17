using System.Collections.Generic;
using MainService.Contracts;
using MainService.Model;
using TddXt.AnyRoot;

namespace CloudMovie.Specification.Factory
{
    public class SpecificationActorResponseFactory : IActorResponseFactory
    {
        public Actor New(Actor actor)
        {
            return actor;
        }

        public List<Actor> AllActorsFor(string title)
        {
            return Root.Any.Instance<List<Actor>>();
        }
    }
}