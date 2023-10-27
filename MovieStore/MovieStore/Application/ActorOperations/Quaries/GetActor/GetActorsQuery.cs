using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;
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

        public List<GetActorViewModel> Handle()
        {
            var actors = _context.Actors
                .Where(x => x.IsActive == true)
                //.Include(x => x.ActorMovie)
                .OrderBy(x => x.Id)
                .ToList();
            List<GetActorViewModel> actorsList = _mapper.Map<List<GetActorViewModel>>(actors);
            
            return actorsList;
        }

        public class GetActorViewModel
        {
            public int Id { get; set; }
            public string? ActorName { get; set; }
            public string? ActorSurname { get; set; }
            public ICollection<Movie>? ActorMovie { get; set; }
        }
    }
}
