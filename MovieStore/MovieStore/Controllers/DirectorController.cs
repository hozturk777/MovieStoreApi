using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.DirectorOperations.Quaries.GetDirector;
using MovieStore.Application.DirectorOperations.Quaries.GetDirectorDetails;
using MovieStore.DbOperations;

namespace MovieStore.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("list/director")]
        public IActionResult GetDirector()
        {
            GetDirectorQuery query = new GetDirectorQuery(_context, _mapper);
            var handle = query.Handle();
            return Ok(handle);
        }
        [HttpGet("list/directorDetails")]
        public IActionResult GetDirectorDetails()
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(_context, _mapper);
            var handle = query.Handle();
            return Ok(handle);
        }
    }
}
