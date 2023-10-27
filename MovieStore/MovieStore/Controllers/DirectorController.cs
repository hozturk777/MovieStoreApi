using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.DirectorOperations.Commands.CreateDirector;
using MovieStore.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStore.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStore.Application.DirectorOperations.Quaries.GetDirector;
using MovieStore.Application.DirectorOperations.Quaries.GetDirectorDetails;
using MovieStore.Application.DirectorOperations.Quaries.GetFalseDirectors;
using MovieStore.DbOperations;
using static MovieStore.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static MovieStore.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;

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

        [HttpGet("list/falseDirector")]
        public IActionResult GetFalseDirector()
        {
            GetFalseDirectorQuery query = new GetFalseDirectorQuery(_context, _mapper);
            var handle = query.Handle();
            return Ok(handle);
        }

        [HttpPost("create/director")]
        public IActionResult CreateDirector([FromBody] CreateDirectorModel model)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok();
        }

        [HttpPut("update/director")]
        public IActionResult UpdateDirector(int? Id,[FromBody]UpdateDirectorModel model)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.Model = model;
            command.DirectorId = Id;
            command.Handle();
            return Ok();

        }

        [HttpDelete("delete/director")]
        public IActionResult DeleteDirector(int? Id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = Id;
            command.Handle();
            return Ok();
        }
    }
}
