using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using static MovieStore.Application.ActorOperations.Quaries.GetActor.GetActors;

namespace MovieStore.Application.DirectorOperations.Quaries.GetDirector
{
    public class GetDirectorQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetDirectorQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetDirectorViewModel> Handle()
        {
            var director = _context.Directors
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Id)
                .ToList();
            
            List<GetDirectorViewModel> directorList = _mapper.Map<List<GetDirectorViewModel>>(director);
            return directorList;
        }

        public class GetDirectorViewModel
        {
            public string? DirectorName { get; set; }
            public string? DirectorSurname { get; set; }
        }
    }
}
