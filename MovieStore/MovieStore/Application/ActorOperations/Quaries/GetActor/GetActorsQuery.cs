using AutoMapper;
using MovieStore.DbOperations;
using static MovieStore.Application.MovieOperations.Quaries.GetMovies.GetMoveisQuery;

namespace MovieStore.Application.ActorOperations.Quaries.GetActor
{
    public class GetActorsQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ActorViewModel> Handle()
        {
            var actors = _context.Actors.OrderBy(x => x.Id).ToList();
            List<ActorViewModel> actorsList = _mapper.Map<List<ActorViewModel>>(actors);
            return actorsList;
        }

        public class ActorViewModel
        {
            public int Id { get; set; }
            public string? ActorName { get; set; }
            public string? ActorSurname { get; set; }
        }
    }
}
