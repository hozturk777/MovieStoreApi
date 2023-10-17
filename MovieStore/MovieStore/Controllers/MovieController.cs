using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.Application.MovieOperations.Quaries.GetMovies;
using MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails;
using MovieStore.DbOperations;
using static MovieStore.Application.MovieOperations.Commands.CreateMovie.CreateMoviesQuery;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieContext _movieContext;
        private readonly IMapper _mapper;

        public MovieController(IMovieContext movieContext, IMapper mapper)
        {
            _movieContext = movieContext;
            _mapper = mapper;
        }

        [HttpGet("list/movie/")]
        public IActionResult GetMovies()
        {
            GetMoveisQuery getMoveisQuery = new GetMoveisQuery(_movieContext, _mapper);
            var result = getMoveisQuery.Handle();
            return Ok(result);
        }
        [HttpGet("list/movieDetails")]
        public IActionResult GetMoviesDetails()
        {
            GetMoviesDetailsQuery getMoviesDetails = new GetMoviesDetailsQuery(_movieContext, _mapper);
            var result = getMoviesDetails.Handle();
            return Ok(result);
        }
        [HttpPost("create/movie")]
        public IActionResult AddMovie([FromBody] CreateMoviesModel createMoviesModel) 
        {
            CreateMoviesQuery command = new CreateMoviesQuery(_movieContext, _mapper);
            command.Model = createMoviesModel;
            command.Handle();
            return Ok();
        }
    }
}
