using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly IMovieContext _context;
        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        public CreateOrderCommand(IMovieContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            List<Order> orders = new List<Order>();
            var orderDataBase = _context.Orders.OrderBy(x => x.Id).ToList();
            orders.AddRange(orderDataBase);

            List<Customer> customerList = new List<Customer>();
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            customerList.Add(customer);

            List<Movie> movieList = new List<Movie>();
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            movieList.Add(movie);
            
            if (orderDataBase.Count > 0) 
            {
                foreach (var chckCustomer in orders)
                {
                    if (chckCustomer.OrderCustomer.SingleOrDefault(x => x.Id == customer.Id) != null)
                    {
                        List<Movie> chckCustomerMovie = new List<Movie>();
                        chckCustomerMovie.AddRange(chckCustomerMovie);
                        chckCustomerMovie.Add(movie);
                        chckCustomer.OrderMovie = chckCustomerMovie;
                        //_context.Orders.Add(chckCustomer);
                    }
                    else
                    {
                        Order order = new Order();
                        order.OrderCustomer = customerList;
                        order.OrderMovie = movieList;
                        _context.Orders.Add(order);
                    }
                }
            }
            else
            {
                Order order = new Order();
                order.OrderCustomer = customerList;
                order.OrderMovie = movieList;
                _context.Orders.Add(order);
            }

            customer.CustomerCart = movieList;
            _context.SaveChanges();
        }
    }
}
