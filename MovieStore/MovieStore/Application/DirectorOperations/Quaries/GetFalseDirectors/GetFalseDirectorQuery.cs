using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;

namespace MovieStore.Application.DirectorOperations.Quaries.GetFalseDirectors
{
    public class GetFalseDirectorQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetFalseDirectorQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetFalseDirectorViewModel> Handle()
        {
            var director = _context.Directors
                .Where(x => x.IsActive == false)
                .Include(x => x.DirectorMovie)
                .OrderBy(x => x.Id)
                .ToList();

            List<GetFalseDirectorViewModel> directorList = _mapper.Map<List<GetFalseDirectorViewModel>>(director);
            return directorList;
        }

        public class GetFalseDirectorViewModel
        {
            public int Id { get; set; }
            public string? DirectorName { get; set; }
            public string? DirectorSurname { get; set; }
            public ICollection<FalseMovieNameViewModel>? DirectorMovie { get; set; }
            public bool IsActive { get; set; }
        }
        public class FalseMovieNameViewModel
        {
            public string? MovieName { get; set; }
            public string? MovieGenre { get; set; }
        }
    }
}
