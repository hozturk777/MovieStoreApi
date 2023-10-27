using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.ActorOperations.Commands.CreateActor;
using MovieStore.Application.ActorOperations.Commands.DeleteActor;
using MovieStore.Application.ActorOperations.Commands.UpdateActor;
using MovieStore.Application.ActorOperations.Quaries.GetActor;
using MovieStore.Application.ActorOperations.Quaries.GetFalseActor;
using MovieStore.DbOperations;
using static MovieStore.Application.ActorOperations.Commands.CreateActor.CreateActorCommand;
using static MovieStore.Application.ActorOperations.Commands.UpdateActor.UpdateActorCommand;

namespace MovieStore.Controllers
{
    public class ActorController : Controller
    {
        private readonly IMovieContext _movieContext;
        private readonly IMapper _mapper;

        public ActorController(IMovieContext context, IMapper mapper)
        {
            _movieContext = context;
            _mapper = mapper;
        }

        [HttpGet("list/actors")]
        public IActionResult GetActors()
        {
            GetActors query = new GetActors(_movieContext, _mapper);
            var handle = query.Handle();
            return Ok(handle);
        }

        [HttpGet("list/falseActors")]
        public IActionResult GetFalseActors()
        {
            GetFalseActorQuery query = new GetFalseActorQuery(_movieContext, _mapper);
            var handle = query.Handle();
            return Ok(handle);
        }

        [HttpPost("create/actor")]
        public IActionResult CreateActor([FromBody] CreateActorModel model)
        {
            CreateActorCommand command = new CreateActorCommand(_movieContext, _mapper);
            command.Model = model;
            command.Handle();
            return Ok();
        }

        [HttpPut("update/actor")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel model)
        {
            UpdateActorCommand command = new UpdateActorCommand(_movieContext);
            command.Id = id;
            command.Model = model;
            command.Handle();
            return Ok();
        }

        [HttpDelete("delete/actor")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_movieContext);
            command.Id = id;
            command.Handle();
            return Ok();
        }
    }
}
