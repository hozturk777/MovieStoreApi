using MovieStore.DbOperations;

namespace MovieStore.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieContext _context;
        public int? DirectorId { get; set; }

        public DeleteDirectorCommand(IMovieContext context)
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
            director.IsActive = false;
            _context.SaveChanges();
        }
    }
}
