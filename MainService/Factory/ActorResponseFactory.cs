using System.Collections.Generic;
using System.Linq;
using MainService.Contracts;
using MainService.Model;

namespace MainService.Factory
{
    public class ActorResponseFactory : IActorResponseFactory
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMovieRepository _movieRepository;

        public ActorResponseFactory(IActorRepository actorRepository, IMovieRepository movieRepository)
        {
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
        }

        public Actor New(Actor actor)
        {
            return _actorRepository.Create(actor);
        }

        public List<Actor> AllActorsFor(string title)
        {
            var movies = _movieRepository
                .RetrieveAll()
                .Where(x => x.Title == title);
            var actors = movies.SelectMany(x => x.Starring);
            return _actorRepository.RetrieveAll()
                .Where(a => actors.Contains(a))
                .ToList();
        }
    }
}