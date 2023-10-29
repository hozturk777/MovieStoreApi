using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.CustomerOperations.CreateCustomer;
using MovieStore.Application.CustomerOperations.CreateRefreshToken;
using MovieStore.Application.CustomerOperations.CreateToken;
using MovieStore.DbOperations;
using MovieStore.TokenOperations.Models;
using static MovieStore.Application.CustomerOperations.CreateCustomer.CreateCustomerCommand;
using static MovieStore.Application.CustomerOperations.CreateToken.CreateTokenCommand;

namespace MovieStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public CustomerController(IMovieContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("create/customer")]
        public ActionResult CreateCustomer([FromBody]CreateCustomerModel model)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _configuration, _mapper);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromBody] string tokens)
        {
            CreateRefreshTokenCommand command = new CreateRefreshTokenCommand(_context, _configuration);
            command.RefreshToken = tokens;


            var token = command.Handle();
            return token;
        }
    }
}
