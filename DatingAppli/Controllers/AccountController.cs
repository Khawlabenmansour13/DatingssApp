using DatingApp.Domaine.Entities;
using Infrastructure.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly DataContexte _contexte;
        public AccountController(DataContexte context) : base(context)
        {
            _contexte = context;


        }
        /*[HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string username , string password)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = username,
                PaawordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            _contexte.Users.Add(user);
            await _contexte.SaveChangesAsync();
            return user;




        } 
        private async Task <bool> UserExists(string username)
        {

        }*/
    }
}
