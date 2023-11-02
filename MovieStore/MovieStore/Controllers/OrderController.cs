using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.OrderOperations.Commands.CreateOrder;
using MovieStore.Application.OrderOperations.Quaries.GerOrder;
using MovieStore.DbOperations;

namespace MovieStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public OrderController(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("list/order")]
        public IActionResult GetOrder()
        {
            GetOrderQuery query = new GetOrderQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost("create/order")]
        public IActionResult CreateOrder(int Customerid, int Movieid) 
        {
            CreateOrderCommand command = new CreateOrderCommand(_context);
            command.CustomerId = Customerid;
            command.MovieId = Movieid;
            command.Handle();
            return Ok();
        }
    }
}
