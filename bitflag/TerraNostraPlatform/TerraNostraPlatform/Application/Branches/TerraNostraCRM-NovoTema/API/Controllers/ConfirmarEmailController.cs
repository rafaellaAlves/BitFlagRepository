using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfirmarEmailController : ControllerBase
    {
        private readonly UserService userService;
        public ConfirmarEmailController(IUserService userService)
        {
            this.userService = (UserService)userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string email, [FromQuery]string token)
        {
            if (await userService.ConfirmEmail(email, token))
                return Ok(new { Mensagem = "E-mail confirmado com sucesso." });
            else
                return BadRequest("E-mail ou token inválido.");
        }
    }
}