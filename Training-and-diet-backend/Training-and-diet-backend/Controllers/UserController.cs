using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController (IUserService userService)
        {
            _service = userService;
        }


        

    }
}
