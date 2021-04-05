using API.Entities.Cadastro;
using API.Entities.Indicacao;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IIndicacaoService
    {
        Task<bool> CheckIfExists(string email, int tipo_servico);
    }

    public class IndicacaoService : IIndicacaoService
    {
        private readonly DB.TerraNostraContext terraNostaContext;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        private readonly Services.TipoServicoService tipoServicoService;

        public IndicacaoService(DB.TerraNostraContext terraNostaContext, UserManager<TerraNostraIdentityDbContext.User> userManager, Services.ITipoServicoService tipoServicoService)
        {
            this.terraNostaContext = terraNostaContext;
            this.userManager = userManager;
            this.tipoServicoService = (Services.TipoServicoService)tipoServicoService;
        }

        public async Task<bool> CheckIfExists(string email, int tipo_servico)
        {
            return await terraNostaContext.Indication.AnyAsync(x => x.Email.ToUpper().Equals(email.ToUpper()) && x.ServiceTypeId == tipo_servico);
        }

        public async Task<bool> Add(IndicacaoViewModel model, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null) return false;

            try
            {
                terraNostaContext.Indication.Add(new DB.Indication()
                {
                    Name = model.Nome,
                    Email = model.Email,
                    Phone = model.Telefone,
                    ServiceTypeId = model.Tipo_Servico,
                    UserId = user.Id,
                    CreatedDate = DateTime.Now
                });
                await terraNostaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<IndicacaoListViewModel>> List(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null) return null;

            try
            {
                return terraNostaContext.Indication.Where(x => x.UserId == user.Id).Select(x => new IndicacaoListViewModel()
                {
                    Nome = x.Name,
                    Data = x.CreatedDate.ToString("dd/MM/yyyy HH:mm"),
                    Status = "Indicado",
                    Comissao = "-"
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<IndicacaoListViewModel>();
            }
        }

        public async Task<string> TerraNostraEmailMessage(IndicacaoViewModel model, TerraNostraIdentityDbContext.User user)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Nova indicação de <b>{user.FirstName + " " + (string.IsNullOrWhiteSpace(user.LastName) ? "" : user.LastName)}</b>!");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Dados da indicação:");
            stringBuilder.AppendLine("<br />");
            stringBuilder.AppendLine("<ul>");
            stringBuilder.AppendLine($"<li>Nome completo: <b>{model.Nome}</b></li>");
            stringBuilder.AppendLine($"<li>E-mail: <b>{model.Email}</b></li>");
            stringBuilder.AppendLine($"<li>Telefone: <b>{model.Telefone}</b></li>");
            stringBuilder.AppendLine($"<li>Serviço: <b>{this.tipoServicoService.ObterNome(model.Tipo_Servico)}</b></li>");
            stringBuilder.AppendLine("</ul>");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Atenciosamente,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Sistemas de Indicações Terra Nostra Assessoria");

            return stringBuilder.ToString();
        }

        public async Task<string> IndicadoEmailMessage(IndicacaoViewModel model)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Olá <b>{model.Nome}</b>,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Recebemos seu contato através de um de nossos parceiros.");
            stringBuilder.AppendLine("<br />");
            stringBuilder.AppendLine($"Nas próximas horas um representante Terra Nostra terá o prazer de entrar contato com você para analisar o seu caso.");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Atenciosamente,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Equipe Terra Nostra Assessoria");

            return stringBuilder.ToString();
        }
    }
}
