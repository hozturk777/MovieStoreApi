using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;
        public int CustomerId { get; set; }
        public UpdateCustomerModel Model { get; set; }

        public UpdateCustomerCommand(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (customer == null) 
            {
                throw new InvalidOperationException("Böyle Bir Kullanıcı Yok!");
            }

            List<Movie> movieList = returnCustomerCart(Model.CustomerCartId);
            List<Genre> genreList = returnCustomerFavGenre(Model.CustomerFavGenresId);
            

            customer.CustomerName = Model.CustomerName != default ? Model.CustomerName : customer.CustomerName;
            customer.CustomerSurname = Model.CustomerSurname != default ? Model.CustomerSurname : customer.CustomerSurname;
            customer.Email = Model.Email != default ? Model.Email : customer.Email;
            customer.Password = Model.Password != default ? Model.Password : customer.Password;
            customer.CustomerCart = movieList.Any() ? movieList : customer.CustomerCart;
            customer.CustomerFavGenres = genreList.Any() ? genreList : customer.CustomerFavGenres;

            Customer customerList = _mapper.Map<Customer>(customer);

            //var cstm = new List<Customer> { customer };
            addOrder(customerList); 
            _context.SaveChanges();
        }
        //  ORDER
        public void addOrder(Customer customerList)
        {
            List<Customer> customer = new List<Customer>();
            customer.Add(customerList);

            if (customerList.CustomerCart != null)
            {
                _context.Orders.Add(
                   new Order
                   {
                       OrderCustomer = customer,
                       OrderMovie = customerList.CustomerCart
                   }
               );
                _context.SaveChanges();
            }
        }

        public List<Movie> returnCustomerCart(List<int> CartId)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (var Id in CartId)
            {
                var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);
                if (movie is null)
                {
                    throw new InvalidOperationException("Böyle Bir Film yok!");
                }
                movieList.Add(movie);
            }
            return movieList;
        }

        public List<Genre> returnCustomerFavGenre(List<int> GenreId)
        {
            List<Genre> genreList = new List<Genre>();
            foreach (var Id in GenreId)
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
            public List<int>? CustomerCartId { get; set; }
            public List<int>? CustomerFavGenresId { get; set; }
        }

        public class GetCustomerViewModel
        {
            public int Id { get; set; }
            public string? CustomerName { get; set; }
            public string? CustomerSurname { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            //public string? RefreshToken { get; set; }
            //public DateTime RefreshTokenExpireDate { get; set; }
            public ICollection<Movie>? CustomerCart { get; set; }
            public ICollection<Genre>? CustomerFavGenres { get; set; }
        }
    }
}
