using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthenticateProject.Repository;
using RoleBasedAuthenticateProject.RequestModels;

namespace RoleBasedAuthenticateProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _interface;

        public UserController(IUserInterface interfacee)
        {
            _interface = interfacee;
        }

        [HttpGet]
        [Route("GetUsers")]

        public IActionResult GetUsers()
        {
            var data = _interface.GetUser();
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveUserDetails")]

        public IActionResult SaveEmployee(AddUserViewModel add)
        {
            var data = _interface.AddUserDetails(add);
            return Ok(data);
        }
    }
}
