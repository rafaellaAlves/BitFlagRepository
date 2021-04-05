using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Indicacao;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class IndicacaoController : ControllerBase
    {
        private readonly IndicacaoService indicacaoService;
        private readonly EmailService emailService;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        public IndicacaoController(IIndicacaoService indicacaoService, IEmailService emailService, UserManager<TerraNostraIdentityDbContext.User> userManager)
        {
            this.indicacaoService = (IndicacaoService)indicacaoService;
            this.emailService = (EmailService)emailService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IndicacaoViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome)) return BadRequest("Por favor, preencha o nome completo de sua indicação.");
            if (string.IsNullOrWhiteSpace(model.Email)) return BadRequest("Por favor, preencha o e-mail de sua indicação.");
            if (string.IsNullOrWhiteSpace(model.Telefone)) return BadRequest("Por favor, preencha o telefone de sua indicação.");

            if (await indicacaoService.CheckIfExists(model.Email, model.Tipo_Servico)) return StatusCode(409, "Indicação já foi cadastrada.");

            if (!await indicacaoService.Add(model, User.Identity.Name)) return StatusCode(500, "Houve um erro ao criar sua indicação.");

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            emailService.Send("Recebemos seu contato!", await indicacaoService.IndicadoEmailMessage(model), new List<string>() { model.Email });
#if !DEBUG
            emailService.Send("Nova indicação!", await indicacaoService.TerraNostraEmailMessage(model, user), new List<string>() { "vagner@terranostracidadania.com.br" });
#else
            emailService.Send("Nova indicação!", await indicacaoService.TerraNostraEmailMessage(model, user), new List<string>() { "yuriasa@gmail.com" });
#endif

            return Ok(new { Mensagem = "Indicação adicionada com sucesso!" });
        }

        [HttpGet]
        public async Task<List<IndicacaoListViewModel>> Get()
        {
            return await indicacaoService.List(User.Identity.Name);
        }
    }
}