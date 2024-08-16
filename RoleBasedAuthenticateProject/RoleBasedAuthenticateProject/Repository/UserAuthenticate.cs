using Microsoft.IdentityModel.Tokens;
using RoleBasedAuthenticateProject.Models;
using RoleBasedAuthenticateProject.RequestModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAuthenticateProject.Repository
{
    public class UserAuthenticate:IUserAuthenticate
    {

        public IConfiguration _configuration;

        public readonly sdirectdbContext _context;

        public UserAuthenticate(IConfiguration configuration, sdirectdbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public ResponseModel Authenticate(UserCredential user)
        {
            ResponseModel response = new ResponseModel();
            

            var obj = _context.MyLoginTable227s.Where(i => i.UserEmail == user.UserEmail && i.UserPassword == user.UserPassword).FirstOrDefault();
            if (obj != null)
            {
    
                response.ResponseMessage = "Valid User";
                response.Token = GenerateJSOWebToken(user);

                return response;

            }
            else
            {
                response.ResponseMessage = "Invalid";
                return response;
            }
        }


        public string GenerateJSOWebToken(UserCredential info)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var objdata = (from map in _context.UserRoleMapping227s
                           join rollmaster in _context.RoleMaster227s on map.RoleId equals rollmaster.RoleId
                           join u in _context.MyLoginTable227s on map.UserId equals u.UserId
                           where u.UserEmail== info.UserEmail
                           select new { map, rollmaster}
                           ).ToList();
              var claims = new List<Claim>
            {

                new Claim(ClaimTypes.Email,info.UserEmail),
                //new Claim(ClaimTypes.Role,"employee")
            };
            if(objdata!=null)
            {
                foreach(var o in objdata)
                {
                    claims.Add(new Claim(ClaimTypes.Role, o.rollmaster.Role));
                }
            }
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                 signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
