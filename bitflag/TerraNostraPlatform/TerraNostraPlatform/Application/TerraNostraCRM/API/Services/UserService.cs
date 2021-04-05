using API.Entities.Cadastro;
using API.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace API.Services
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings appSettings;
        private readonly SignInManager<TerraNostraIdentityDbContext.User> signInManager;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        private readonly RoleManager<TerraNostraIdentityDbContext.Role> roleManager;
        private readonly DB.TerraNostraContext terraNostaContext;
        public UserService(IOptions<AppSettings> appSettings, SignInManager<TerraNostraIdentityDbContext.User> signInManager, UserManager<TerraNostraIdentityDbContext.User> userManager, RoleManager<TerraNostraIdentityDbContext.Role> roleManager, DB.TerraNostraContext terraNostaContext)
        {
            this.appSettings = appSettings.Value;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.terraNostaContext = terraNostaContext;
        }

        public async Task<bool> CreateUser(CadastroViewModel model)
        {
            var result = await userManager.CreateAsync(new TerraNostraIdentityDbContext.User()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.Nome,
                LastName = string.Empty,
                CPF = Regex.Replace(model.CPF, @"[^\d]", ""),
                CreatedDate = DateTime.Now,
                IsActive = true
            }, model.Senha);

            if(result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                await userManager.AddToRoleAsync(user, "AGENT");
            }

            return result.Succeeded;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            using (var context = new DB.TerraNostraContext())
            {
                var user = await userManager.FindByNameAsync(username);
                if (user == null) return null;

                var result = await userManager.CheckPasswordAsync(user, password);
                if (!result) return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.JWTSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }

        public async Task<bool> CheckIfEmailExists(string email)
        {
            return await this.userManager.FindByEmailAsync(email) == null ? false : true;
        }

        public async Task<bool> CheckIfCPFExists(string cpf)
        {
            var _cpf = Regex.Replace(cpf, @"[^\d]", "");
            return await this.terraNostaContext.User.AnyAsync(x => x.Cpf == _cpf);
        }

        public async Task<bool> CheckIfEmailIsConfirmed(string email)
        {
            var user = await this.userManager.FindByEmailAsync(email);
            return await this.userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<bool> ConfirmEmail(string email, string token)
        {
            var user = await this.userManager.FindByEmailAsync(email);
            if (user == null) return false;
            var result = await this.userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<string> ConfirmEmailMessage(CadastroViewModel model, string baseLink)
        {
            var stringBuilder = new StringBuilder();

            var token = await userManager.GenerateEmailConfirmationTokenAsync(await userManager.FindByEmailAsync(model.Email));

            var url = $"{baseLink}?email={HttpUtility.UrlEncode(model.Email)}&token={HttpUtility.UrlEncode(token)}";

            stringBuilder.AppendLine($"Olá <b>{model.Nome}</b>,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Obrigado por baixar o nosso aplicativo. Em breve você estará pronto para começar as suas indicações!");
            stringBuilder.AppendLine("<br />");
            stringBuilder.AppendLine($"Para isso, por favor, confirme seu e-mail por meio desse <a href=\"{url}\">link</a>.");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Atenciosamente,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Equipe Terra Nostra Assessoria");

            return stringBuilder.ToString();
        }

        public async Task<bool> IsActive(string email)
        {
            var user = await this.userManager.FindByEmailAsync(email);
            return user.IsActive;
        }
    }
}
