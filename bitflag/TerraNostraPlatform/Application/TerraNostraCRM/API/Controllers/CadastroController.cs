using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Cadastro;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly UserService userService;
        private readonly EmailService emailService;
        public CadastroController(IUserService userService, IEmailService emailService)
        {
            this.userService = (UserService)userService;
            this.emailService = (EmailService)emailService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CadastroViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome)) return BadRequest("Por favor, preencha seu nome completo.");
            if (string.IsNullOrWhiteSpace(model.Email)) return BadRequest("Por favor, preencha sua e-mail.");
            if (string.IsNullOrWhiteSpace(model.CPF)) return BadRequest("Por favor, preencha seu CPF.");
            if (string.IsNullOrWhiteSpace(model.Senha)) return BadRequest("Por favor, preencha sua senha.");

            if (this.userService.CheckIfEmailExists(model.Email).Result) return StatusCode(409, "E-mail já cadastrado.");
            if (this.userService.CheckIfCPFExists(model.CPF).Result) return StatusCode(409, "CPF já cadastrado.");
            if (model.Senha.Length < 6) return BadRequest("Sua senha deve ter no mínimo 6 caracteres.");

            var userCreated = userService.CreateUser(model).Result;
            if (!userCreated) return StatusCode(500, "Não foi possível criar seu usuário.");

            var message = userService.ConfirmEmailMessage(model, Helpers.UrlHelpers.GetBaseUrl(HttpContext) + "/api/ConfirmarEmail").Result;

            emailService.Send("Seja bem-vindo ao aplicativo Terra Nostra!", message, new List<string>() { model.Email });

            return Ok(new { Mensagem = "Parabéns! Um e-mail com informações adicionais foi enviado para sua caixa de entrada." });
        }
    }
}