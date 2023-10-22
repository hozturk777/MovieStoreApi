using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;
        public CreateActorModel Model { get; set; }

        public CreateActorCommand(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actors = _context.Actors.SingleOrDefault(x => x.ActorName == Model.ActorName);
            if (actors != null)
            {
                throw new InvalidOperationException("Böyle Bir Actor Zaten Mevcut!");
            }
            actors = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actors);
            _context.SaveChanges();
        }

        public class CreateActorModel
        {
            public string? ActorName { get; set; }
            public string? ActorSurname { get; set; }
        }
    }
}
