using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;

namespace MovieStore.Application.DirectorOperations.Quaries.GetDirectorDetails
{
    public class GetDirectorDetailsQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetDirectorDetailsQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetDirectorDetailsViewModel> Handle()
        {
            var director = _context.Directors
                .Where(x => x.IsActive == true)
                .Include(x => x.DirectorMovie)
                .OrderBy(x => x.Id)
                .ToList();

            List<GetDirectorDetailsViewModel> directorList = _mapper.Map<List<GetDirectorDetailsViewModel>>(director);
            return directorList;
        }

        public class GetDirectorDetailsViewModel
        {
            public int Id { get; set; }
            public string? DirectorName { get; set; }
            public string? DirectorSurname { get; set; }
            public ICollection<MovieNameViewModel>? DirectorMovie { get; set; }
            public bool IsActive { get; set; }
        }
        public class MovieNameViewModel
        {
            public string? MovieName { get; set; }
            public string? MovieGenre { get; set; }
        }
    }
}
