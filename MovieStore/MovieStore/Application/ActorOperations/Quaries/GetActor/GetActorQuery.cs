using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.Application.ActorOperations.Quaries.GetActor
{
    public class GetActorQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetActorQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActorViewModel> Handle()
        {
            var actor = _context.Actors
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Id)
                .ToList();

            List<GetActorViewModel> actorList = _mapper.Map<List<GetActorViewModel>>(actor);
            return actorList;
        }

        public class GetActorViewModel
        {
            public string? ActorName { get; set; }
            public string? ActorSurname { get; set; }
        }
    }
}
