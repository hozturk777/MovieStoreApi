using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.Application.MovieOperations.Commands.DeleteMovie;
using MovieStore.Application.MovieOperations.Commands.UpdateMovie;
using MovieStore.Application.MovieOperations.Quaries.GetMovies;
using MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails;
using MovieStore.DbOperations;
using MovieStore.Entities;
using static MovieStore.Application.MovieOperations.Commands.CreateMovie.CreateMoviesQuery;
using static MovieStore.Application.MovieOperations.Commands.UpdateMovie.UpdateMoviesQuery;

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

        [HttpPut("update/movie")]
        public IActionResult UpdateMovie(int id,[FromBody] UpdateMovieViewModel updateMovieViewModel)
        {
            UpdateMoviesQuery command = new UpdateMoviesQuery(_movieContext);
            command.Model = updateMovieViewModel;
            command.MovieId = id;

            command.Handle();
            return Ok();
        }

        [HttpDelete("delete/movie")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMoviesQuery command = new DeleteMoviesQuery(_movieContext);
            command.MovieId = id;
            command.Handle();
            return Ok();
        }
    }
}
