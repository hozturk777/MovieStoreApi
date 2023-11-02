using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly IMovieContext _context;
        public int? CustomerId { get; set; }
        public UpdateCustomerModel Model { get; set; }

        public UpdateCustomerCommand(IMovieContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (customer == null) 
            {
                throw new InvalidOperationException("Böyle Bir Kullanıcı Yok!");
            }


            //ICollection<Movie> movies = new List<Movie>();
            //Movie movie = GetMovieByID(movieUpdate.MovieActorId);
            //if (actor.IsActive)
            //{
            //    actors.Add(actor);
            //    movieUpdate.MovieActor = actors;
            //}
            //else
            //{
            //    throw new InvalidOperationException("Öyle Bir Aktör Yok!");
            //}



            customer.CustomerName = Model.CustomerName != default ? Model.CustomerName : customer.CustomerName;
            customer.CustomerSurname = Model.CustomerSurname != default ? Model.CustomerSurname : customer.CustomerSurname;
            customer.Email = Model.Email != default ? Model.Email : customer.Email;
            customer.Password = Model.Password != default ? Model.Password : customer.Password;
            customer.CustomerCartId = Model.CustomerCartId != null ? Model.CustomerCartId : customer.CustomerCartId;
            
            List<Movie> movies = new List<Movie>();
            Movie movie = returnCustomerCart(customer.CustomerCartId);
            movies.Add(movie);
            customer.CustomerCart = movies;
            _context.SaveChanges();
        }




        public Movie returnCustomerCart(int? CartId)
        {
            ICollection<Movie>? movieList = new List<Movie>();
                var movie = _context.Movies.SingleOrDefault(x => x.Id == CartId);
                if (movie is null)
                {
                    throw new InvalidOperationException("Böyle Bir Film yok!");
                }
                movieList.Add(movie);
            return movie;
        }

        public List<Genre> returnCustomerFavGenre(List<int> GenreId)
        {
            List<Genre> genreList = new List<Genre>();
            foreach (int Id in GenreId)
            {
                var genre = _context.Genres.SingleOrDefault(x => x.Id == Id);
                if( genre is null)
                {
                    throw new InvalidOperationException("Böyle Bir Tür Yok!");
                }
                genreList.Add(genre);
            }
            return genreList;
        }

        public class UpdateCustomerModel
        {
            public string? CustomerName { get; set; }
            public string? CustomerSurname { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public int? CustomerCartId { get; set; }
            public List<int>? CustomerFavGenresId { get; set; }
        }
    }
}
