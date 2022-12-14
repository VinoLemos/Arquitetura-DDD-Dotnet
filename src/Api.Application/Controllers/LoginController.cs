using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto userDto, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (userDto == null) return BadRequest();

            try
            {
                return await service.FindByLogin(userDto) ?? NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}