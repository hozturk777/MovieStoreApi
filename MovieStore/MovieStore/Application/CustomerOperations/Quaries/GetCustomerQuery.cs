using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.CustomerOperations.Quaries
{
    public class GetCustomerQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetCustomerQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Customer> Handle()
        {
            var customer = _context.Customers
                .Include(x => x.CustomerCart)
                .Include(x => x.CustomerFavGenres)
                .OrderBy(x => x.Id)
                .ToList();

            List<GetCustomerViewModel> customerList = _mapper.Map<List<GetCustomerViewModel>>(customer);
            return customer;
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
            //public int? CustomerCartId { get; set; }
            public ICollection<GetMovieModel>? CustomerCart { get; set; }
            //public ICollection<Genre>? CustomerFavGenres { get; set; }
        }

        public class GetMovieModel
        {
            public int Id { get; set; }
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public string? PublishDate { get; set; }
        }
    }
}
