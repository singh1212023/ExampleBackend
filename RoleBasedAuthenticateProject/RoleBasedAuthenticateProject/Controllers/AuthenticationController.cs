using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthenticateProject.Models;
using RoleBasedAuthenticateProject.Repository;
using RoleBasedAuthenticateProject.RequestModels;

namespace RoleBasedAuthenticateProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly sdirectdbContext _context;
        public IConfiguration _configuration;

        public IUserAuthenticate _authrnticate;

        public AuthenticationController(IConfiguration configuration, sdirectdbContext context, IUserAuthenticate auth)
        {
            _configuration = configuration;
            _context = context;
            _authrnticate = auth;


        }
        
        [HttpPost]
        [Route("AuthenticateUser")]

        public IActionResult AuthenticateUser(UserCredential login)
        {
            return Ok(_authrnticate.Authenticate(login));
        }

       
    }
}





















//[HttpGet]
//[Route("GetAll")]
//[Authorize(Roles = "admin")]

//public IActionResult GetAll()
//{
//    return Ok();
//}


//[HttpGet]
//[Route("GetById")]
//[Authorize(Roles = "admin,Student")]
//public IActionResult GetById()
//{
//    return Ok();
//}

//[HttpPost]
//[Route("PostAll")]
//[Authorize(Roles = "admin")]

//public IActionResult PostAll(string name)
//{
//    return Ok();
//}

//[HttpDelete]
//[Route("Delete")]
//[Authorize(Roles = "admin")]
//public IActionResult Delete(int id)
//{
//    return Ok();
//}