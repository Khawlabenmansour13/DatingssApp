
using AutoMapper;
using DatingApp.Application.Persons.Commands.CreatePerson;
using DatingApp.Application.Persons.Commands.DeletePerson;
using DatingApp.Application.Persons.Commands.UpdatePerson;
using DatingApp.Application.Persons.Queries.GetAllPerson;
using DatingApp.Application.Persons.Queries.GetAllPersonsByEmail;
using DatingApp.Application.Persons.Queries.GetPersonByIdQuery;
using DatingApp.Application.Persons.Responses;
using DatingApp.Application.Users.DTOs;
using DatingApp.Domaine.Entities;
using Infrastructure.DataBase;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonController(ILogger<PersonController> logger, IMediator mediator, IMapper mapper )
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("DisplayPersons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PersonDTOs>> GetAllUsers()
        {
            //return await  _mediator.Send(new GetAllPersonsQuery());
            var result = await this._mediator.Send(new GetAllPersonsQuery());
            return this._mapper.Map<IEnumerable<PersonDTOs>>(result);

        }

        [HttpGet("GetPersons/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PersonDTOs> Get(Guid id)
        {
            // return await _mediator.Send(new GetPersonByIdQuery((Guid)id));
            Person person = await this._mediator.Send(new GetPersonByIdQuery((Guid)id));
            PersonDTOs mappedPerson = this._mapper.Map<PersonDTOs>(person);
            return mappedPerson;
        }

        
        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PersonDTOs> GetUserByEmail(string email)
        {
            //return await _mediator.Send(new GetPersonsByEmailQuery((string)email));
            Person person = await this._mediator.Send(new GetPersonsByEmailQuery((string)email));
            PersonDTOs mappedPerson = this._mapper.Map<PersonDTOs>(person);
            return mappedPerson;
        }
    

        [HttpPost("AddPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PersonResponse>> CreatePerson([FromBody] CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("UpdatePerson/{id}")]
        public async Task<ActionResult> UpdatePerson(Guid id, [FromBody] UpdatePersonCommand command)
        {
            try
            {

                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }


        }
       [HttpDelete("DeletePerson/{id}")]
        public async Task<ActionResult> DeletePerson(Guid id)
        {
            try
            {
                string result = string.Empty;
                 result =_mediator.Send(new DeletePersonCommand(id)).Result.Message;   
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
              
            }
        }
       






    }
}
