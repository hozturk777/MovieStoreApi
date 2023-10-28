using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorModel Model { get; set; }

        public CreateDirectorCommand(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors
                .SingleOrDefault(x => x.DirectorName == Model.DirectorName);
            if (director != null) 
            {
                if(director.IsActive)
                {
                    throw new InvalidOperationException("Bu İsimde Bir Yönetmen Zaten Var!");
                }
                else
                {
                    director.IsActive = true;
                    _context.SaveChanges();
                    throw new InvalidOperationException("Önceden Eklenildi Yönetici Listesini Kontrol Et!");
                }
            }
            director = _mapper.Map<Director>(Model);
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public class CreateDirectorModel
        {
            public string? DirectorName { get; set; }
            public string? DirectorSurname { get; set; }
        }
    }
}
