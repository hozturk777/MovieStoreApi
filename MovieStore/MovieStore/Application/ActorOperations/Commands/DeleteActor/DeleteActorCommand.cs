using MovieStore.DbOperations;

namespace MovieStore.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly IMovieContext _context;
        public int Id { get; set; }

        public DeleteActorCommand(IMovieContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == Id);
            if (actor == null)
            {
                throw new InvalidOperationException("Öyle Bir Actor Yok!");
            }
            actor.IsActive = false;
            _context.SaveChanges();
        }
    }
}
