using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.OrderOperations.Quaries.GerOrder
{
    public class GetOrderQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetOrderQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetOrderViewModel> Handle()
        {
            var order = _context.Orders
                .Include(x => x.OrderCustomer)
                .Include(x => x.OrderMovie)
                .OrderBy(x => x.Id)
                .ToList();

            List<GetOrderViewModel> orderList = _mapper.Map<List<GetOrderViewModel>>(order);

            return orderList;
        }

        public class GetOrderViewModel
        {
            public int Id { get; set; }
            public ICollection<GetCustomerOrderModel> OrderCustomer { get; set; }
            public ICollection<Movie> OrderMovie { get; set; }
            public string SellTime { get; set; }
        }

        public class GetCustomerOrderModel
        {
            public int Id { get; set; }
            public string? CustomerName { get; set; }
            public string? CustomerSurname { get; set; }
            public string? Email { get; set; }
            //public string? Password { get; set; }
            //public string? RefreshToken { get; set; }
            //public DateTime RefreshTokenExpireDate { get; set; }
            //public List<Movie>? CustomerCart { get; set; }
            //public List<Genre>? CustomerFavGenres { get; set; }
        }
        public class GetMovieOrderModel
        {
            public int Id { get; set; }
            public string? MovieName { get; set; }
            public string? Price { get; set; }
        }
    }
}
