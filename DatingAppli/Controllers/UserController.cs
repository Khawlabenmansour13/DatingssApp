using DatingApp.Application.Users.Commands.CreateUser;
using DatingApp.Application.Users.Commands.DeleteUser;
using DatingApp.Application.Users.Commands.UpdateUser;
using DatingApp.Application.Users.Queries.GetAllUser;
using DatingApp.Application.Users.Responses;
using DatingApp.Application.Users.Queries.GetUserByIdQuery;
using DatingApp.Domaine.Entities;
using Infrastructure.DataBase;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApp.Application.Users.Queries.GetAllUserByEmail;

namespace DatingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("DisplayUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<AppUser>> GetAllUsers()
        {
            return await  _mediator.Send(new GetAllUsersQuery());
          
        }

        [HttpGet("GetUsers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AppUser> Get(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery((Guid)id));
        }


        [HttpGet("GetUsers/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _mediator.Send(new GetUserByEmailQuery((string)email));
        }


        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> CreateResponse([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
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
       [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            try
            {
                string result = string.Empty;
                 result =_mediator.Send(new DeleteUserCommand(id)).Result.Message;   
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
              
            }
        }
       






    }
}
