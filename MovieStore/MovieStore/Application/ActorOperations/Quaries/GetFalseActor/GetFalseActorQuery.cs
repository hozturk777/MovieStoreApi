using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;

namespace MovieStore.Application.ActorOperations.Quaries.GetFalseActor
{
    public class GetFalseActorQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetFalseActorQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetFalseActorViewModel> Handle()
        {
            var actors = _context.Actors
                .Where(x => x.IsActive == false)
                .Include(x => x.ActorMovie)
                .OrderBy(x => x.Id)
                .ToList();
            List<GetFalseActorViewModel> actorsList = _mapper.Map<List<GetFalseActorViewModel>>(actors);

            return actorsList;
        }

        public class GetFalseActorViewModel
        {
            public int Id { get; set; }
            public string? ActorName { get; set; }
            public string? ActorSurname { get; set; }
            public ICollection<FalseActorMovieViewModel>? ActorMovie { get; set; }
            public bool IsActive { get; set; }
        }

        public class FalseActorMovieViewModel
        {
            public string? MovieName { get; set; }
            public string? MovieGenre { get; set; }
        }
    }
}
