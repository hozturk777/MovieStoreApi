using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;
using static MovieStore.Application.MovieOperations.Quaries.GetMovies.GetMoveisQuery;

namespace MovieStore.Application.ActorOperations.Quaries.GetActor
{
    public class GetActorsDetailsQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetActorsDetailsQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActorDetailsViewModel> Handle()
        {
            var actors = _context.Actors
                .Where(x => x.IsActive == true)
                .Include(x => x.ActorMovie)
                .OrderBy(x => x.Id)
                .ToList();
            List<GetActorDetailsViewModel> actorsList = _mapper.Map<List<GetActorDetailsViewModel>>(actors);
            
            return actorsList;
        }

        public class GetActorDetailsViewModel
        {
            public int Id { get; set; }
            public string? ActorName { get; set; }
            public string? ActorSurname { get; set; }
            public ICollection<ActorMovieViewModel>? ActorMovie { get; set; }
            public bool IsActive { get; set; }
        }

        public class ActorMovieViewModel
        {
            public string? MovieName { get; set; }
            public string? MovieGenre { get; set; }
        }
    }
}
