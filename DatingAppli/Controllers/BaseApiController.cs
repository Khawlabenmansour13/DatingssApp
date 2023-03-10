using Infrastructure.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly DataContexte _context;
        public BaseApiController(DataContexte context)
        {
            _context = context;
        }
    }
}
