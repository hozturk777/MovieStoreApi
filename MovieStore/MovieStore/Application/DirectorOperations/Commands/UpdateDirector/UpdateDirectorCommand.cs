using MovieStore.DbOperations;
using MovieStore.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieContext _context;
        public int? DirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }

        public UpdateDirectorCommand(IMovieContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Böyle Bir Yönetici Yok!");
            }
            director.DirectorName = Model.DirectorName != default ? Model.DirectorName : director.DirectorName;
            director.DirectorSurname = Model.DirectorSurname != default ? Model.DirectorSurname : director.DirectorSurname;
            _context.SaveChanges();
        }

        public class UpdateDirectorModel
        {
            public string? DirectorName { get; set; }
            public string? DirectorSurname { get; set; }
        }
    }
}
