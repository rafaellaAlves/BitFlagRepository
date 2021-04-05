using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using AspNetIdentityDbContext;
using DTO.Shared;
using DTO.User;
using DTO.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Account;
using Services.Client;
using Services.Email;
using Web.Helpers;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserService userService;
        RoleService roleService;
        EmailServices emailServices;
        ViewEngineHelper viewEngineHelper;

        UserManager<User> userManager;

        ClientUserServices clientUserServices;
        ClientServices clientServices;
        public UserController(UserService userService, RoleService roleService, ClientUserServices clientUserServices, ClientServices clientServices, UserManager<User> userManager, EmailServices emailServices, ViewEngineHelper viewEngineHelper)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.clientUserServices = clientUserServices;
            this.clientServices = clientServices;
            this.userManager = userManager;
            this.emailServices = emailServices;
            this.viewEngineHelper = viewEngineHelper;
        }
        public async Task<IActionResult> Index(string q) => await Task.Run(() => View((object)q));
        public async Task<IActionResult> Client(string q) => await Task.Run(() => RedirectToAction("Index", new { q, userType = (int)UserType.Client }));
        public async Task<IActionResult> Administrator(string q) => await Task.Run(() => RedirectToAction("Index", new { q, userType = (int)UserType.Adminsitrator }));

        public async Task<IActionResult> Manage(int? id)
        {
            if (User.IsClient() && id.HasValue)
            {
                var userId = (await userManager.GetUserAsync(User)).Id;
                var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);

                if (!await clientUserServices.ClientHasUser(userId) || !await clientUserServices.dbSet.AnyAsync(x => x.ClientId == clientId && x.UserId == id))
                    return await Task.Run(() => Forbid());
            }

            return await Task.Run(() => View(id));
        }
        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(DTO.User.UserViewModel model, int? clientId)
        {
            if (model.RoleName == "Cliente" && !model.UserId.HasValue)
            {
                model.Password ??= "123456";
                model.PasswordConfirmation ??= "123456";
            }

            if (User.IsClient())
            {
                clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
                if (await clientUserServices.GetTotalUsersByClient(clientId.Value) > 3 && !model.UserId.HasValue) return await Task.Run(() => Forbid());
            }

            try
            {
                if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName))
                    return await Task.Run(() => Json(new ReturnResult(null, "Por favor, preencha nome e sobrenome.", true)));

                if (!model.UserId.HasValue && (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6))
                    return await Task.Run(() => Json(new ReturnResult(null, "Por favor, preencha uma senha de no mínimo 6 caracteres.", true)));

                if (!string.IsNullOrWhiteSpace(model.Password) && model.Password != model.PasswordConfirmation)
                    return await Task.Run(() => Json(new ReturnResult(null, "Senha e confirmação não coincidem.", true)));

                if (!model.UserId.HasValue && await this.userService.EmailExists(model.Email))
                    return await Task.Run(() => Json(new ReturnResult(null, "Este e-mail já está sendo utilizado.", true)));

                if (User.IsClient()) //Caso seja um usuário de perfil "Cliente" sempre será criado/atualizado clientes com o mesmo perfil
                {
                    model.RoleName = "Cliente";
                }

                if (User.IsInRole("Administrator") && clientId.HasValue && !model.UserId.HasValue) // Se o adminsitrador esta criando o usuário a senha do novo usuário será temporário, sendo necessário redefini-la no login
                    model.TemporaryPassword = true;

                var userId = await this.userService.ManageUser(model);

                if (clientId.HasValue) //Caso seja um usuário de perfil "Cliente" insere o usuário criado no mesmo gerador do usuário logado
                {
                    if (!await clientUserServices.dbSet.AnyAsync(x => x.UserId == userId))
                    {
                        await clientUserServices.CreateAsync(new ApplicationDbContext.Models.ClientUser
                        {
                            UserId = userId,
                            ClientId = clientId.Value
                        });
                    }

                    //if (!model.UserId.HasValue && User.IsInRole("Administrator"))//É enviado um e-mail para com o usuário criado
                    //{
                    //    await SendNewClientUserEmail(new NewClientUserEmailViewModel 
                    //    {
                    //        User = model,
                    //        Client = await clientServices.GetViewModelByIdAsync(clientId.Value)
                    //    });
                    //}
                }

                return await Task.Run(() => Json(new ReturnResult(userId, null, false)));
            }
            catch (Exception exception)
            {
                return await Task.Run(() => Json(new ReturnResult(null, exception.Message, true)));
            }
        }


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.userService.DeleteUser(id);
                return await Task.Run(() => Json(new ReturnResult(id, null, false)));
            }
            catch (Exception exception)
            {
                return await Task.Run(() => Json(new ReturnResult(null, exception.Message, true)));
            }
        }
        public async Task<IActionResult> UserIndexViewComponent(DTO.User.UserType? userType) => await Task.Run(() => ViewComponent(typeof(ViewComponents.User.UserIndexViewComponent), new { userType }));

        public async Task<IActionResult> SendNewClientUserEmail(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            var client = await clientUserServices.GetClientByUser(userId);

            if (client == null)
                return await Task.Run(() => Json(new ReturnResult(null, " usuário ainda não esta vinculado a nenhum gerador.", true)));

            try
            {
                var password = DTO.Utils.StringExtensions.GetReference();

                await userManager.ResetPasswordAsync(user, await userManager.GeneratePasswordResetTokenAsync(user), password);

                var userViewModel = await userService.GetUser(userId);
                userViewModel.Password = password;

                await SendNewClientUserEmail(new NewClientUserEmailViewModel
                {
                    User = userViewModel,
                    Client = clientServices.ToViewModel(client)
                });

                return await Task.Run(() => Json(new ReturnResult(null,"E-mail enviado com sucesso!", false)));
            }
            catch (Exception ex)
            {
                return await Task.Run(() => Json(new ReturnResult(null, ex.Message, true)));
            }
        }

        async Task SendNewClientUserEmail(DTO.User.NewClientUserEmailViewModel model)
        {
            var html = await viewEngineHelper.RenderPartialViewToString(ControllerContext, ViewData, TempData, "NewClientUserEmail", model);

            emailServices.Send($"Destine Já - Sua Coleta de Resíduos - Senha de Acesso", html, model.User.Email.Split(";").ToList(), null, null, null, new List<LinkedResource> { new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg) { ContentId = "Logo" } }, false);
        }
    }
}