using MovieStore.DbOperations;
using MovieStore.Entities;
using System.Linq;

namespace MovieStore.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly IMovieContext _movieContext;
        public int Id { get; set; }
        public UpdateActorModel Model { get; set; }

        public UpdateActorCommand(IMovieContext context)
        {
            _movieContext = context;
        }

        public void Handle()
        {
            var actor = _movieContext.Actors.SingleOrDefault(x => x.Id == Id);
            if (actor == null)
            {
                throw new InvalidOperationException("Öyle Bir Actor Yok!");
            }
            actor.ActorName = Model.Actorname != default ? Model.Actorname : actor.ActorName;
            actor.ActorSurname = Model.ActorSurname != default ? Model.ActorSurname : actor.ActorSurname;
            actor.ActorMovieId = Model.ActorMovieId;

            _movieContext.SaveChanges();
        }

        public class UpdateActorModel
        {
            public string? Actorname { get; set; }
            public string? ActorSurname { get; set; }
            public int? ActorMovieId { get; set; }
        }
    }
}
