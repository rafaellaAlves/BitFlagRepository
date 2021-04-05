using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Login;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService userService;
        public LoginController(IUserService userService)
        {
            this.userService = (UserService)userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email)) return BadRequest("Por favor, preencha seu e-mail.");
            if (string.IsNullOrWhiteSpace(model.Senha)) return BadRequest("Por favor, preencha sua senha.");

            var jwt = await userService.Authenticate(model.Email, model.Senha);
            if (string.IsNullOrWhiteSpace(jwt))
                return StatusCode(403, "Usuário ou senha inválidas.");
            
            if(!await userService.CheckIfEmailIsConfirmed(model.Email))
                return StatusCode(403, "Por favor, confirme seu e-mail. Verifique sua caixa postal.");

            if (!await userService.IsActive(model.Email))
                return StatusCode(403, "Atenção, seu usuário ainda não está ativo. Por favor, aguarde a liberação.");

            return Ok(new { Mensagem = jwt });
        }
    }
}