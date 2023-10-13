using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.MovieOperations.Quaries.GetMovies;
using MovieStore.DbOperations;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieContext _movieContext;
        private readonly IMapper _mapper;

        public MovieController(IMovieContext movieContext, IMapper mapper)
        {
            _movieContext = movieContext;
            _mapper = mapper;
        }

        [HttpGet("list/")]
        public IActionResult GetMovies()
        {
            GetMoveisQuery getMoveisQuery = new GetMoveisQuery(_movieContext, _mapper);
            var result = getMoveisQuery.Handle();
            return Ok(result);
        }
    }
}
