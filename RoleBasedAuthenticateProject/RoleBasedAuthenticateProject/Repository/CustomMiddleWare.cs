
using RoleBasedAuthenticateProject.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace RoleBasedAuthenticateProject.Repository
{
    public class CustomMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly sdirectdbContext _context;

        public CustomMiddleWare(RequestDelegate next , sdirectdbContext context)
        {
            _next = next;
            _context  = context;
        }

        public   async Task InvokeAsync(HttpContext http,RequestDelegate next)
        {

            //string ApiIp = _context.connection.RemoteIpAddress?.ToString();
            //string apiname = _context.Request.Path.Value;
            Console.WriteLine("hel");
            await _next(http);
        }
    }

    public class AddMiddleWare
    {
        public string? MiddleWareIp { get; set; }
        public string? MiddleWareName { get; set; }
    }
}
