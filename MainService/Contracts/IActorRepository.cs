using System.Collections.Generic;
using MainService.Model;

namespace MainService.Contracts
{
    public interface IActorRepository
    {
        Actor Create(Actor actor);
        IEnumerable<Actor> RetrieveAll();
    }
}