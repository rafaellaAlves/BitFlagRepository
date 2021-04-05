using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly FUNCTIONS.Message.MessageFunctions messageFunctions;
        private readonly FUNCTIONS.Ticket.TicketHistoryFunctions ticketHistoryFunctions;
        private readonly FUNCTIONS.Ticket.TicketFunctions ticketFunctions;
        private readonly FUNCTIONS.User.UserFunctions userFunctions;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;

        public MessageController(FUNCTIONS.Message.MessageFunctions messageFunctions, FUNCTIONS.Ticket.TicketHistoryFunctions ticketHistoryFunctions, FUNCTIONS.Ticket.TicketFunctions ticketFunctions, FUNCTIONS.User.UserFunctions userFunctions, UserManager<TerraNostraIdentityDbContext.User> userManager)
        {
            this.messageFunctions = messageFunctions;
            this.ticketHistoryFunctions = ticketHistoryFunctions;
            this.ticketFunctions = ticketFunctions;
            this.userFunctions = userFunctions;
            this.userManager = userManager;
        }

        #region [SHARED]
        public string GetNewMessageStyleEmail()
        {
            return "<style>" +
                    "table {" +
                        "border-spacing: 0;" +
                        "width: 60% !important;" +
                        "margin-left:20% !important;" +
                    "}" +
                    ".tx-center{" +
                        "text-align: center;" +
                    "}" +
                    ".bg-lightgrey{" +
                        "background-color: #f4f4f4;" +
                    "}" +
                    ".pd-l{" +
                        "padding-left: 10px;" +
                    "}" +
                "</style>";
        }

        public string GetNewMessageTextEmail(DB.Message message, DB.Ticket ticket, TerraNostraIdentityDbContext.User sender, TerraNostraIdentityDbContext.User receiver, out List<LinkedResource> linkedResources)
        {
            linkedResources = new List<LinkedResource>();
            int index = 1;
            if (message.Text.Contains("<img src=\""))
            {
                var _src = message.Text.Split("<img src=\"");
                do
                {
                    var src = _src[index].Split("\" ")[0];
                    message.Text = message.Text.Replace(src, "cid:img" + index);
                    var imageData = Convert.FromBase64String(src.Replace("data:image/png;base64,", ""));
                    LinkedResource pic = new LinkedResource(new MemoryStream(imageData), MediaTypeNames.Image.Jpeg);
                    pic.ContentId = "img" + index;

                    linkedResources.Add(pic);
                    index++;
                } while (message.Text.Contains("<img src=\"data:image"));
            }

            message.Text = message.Text.Replace("table-bordered\"", "\" border=\"1\""); //troca a classe table-bordered pelo atributo borda(as tabelas do SummerNote que vem com table-bordered)

            return "Olá <b>" + receiver.FirstName + (string.IsNullOrWhiteSpace(receiver.LastName) ? "" : " " + receiver.LastName) + "</b>," +
                "<br />" +
                "Foi enviada uma mensagem referente ao Ticket <b>#" + ticket.TicketId + "</b>, veja mais detalhes abaixo ou <a href =\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Message", "Ticket") + "?id=" + ticket.TicketId + "\">clique aqui</a> para ser redirecionado para a pagina." +
                "<br /><br /><br />" +
                "<div>" +
                "<table>" +
                    "<tbody>" +
                        "<tr class='tx-center'>" +
                            "<td style='border-radius: 10px 10px 0px 0px;background-color: #b7b7b7;border: 1px solid black;border-bottom: 0;'>NOVA MENSAGEM</td>" +
                        "</tr> " +
                    "</tbody> " +
                "</table>" +
                "<table style='border: 1px solid black; /* margin-top: .2em; */'>" +
                    "<tbody>" +
                        "<tr class='bg-lightgrey'>" +
                            "<td colspan='2'><b class='pd-l'>Ticket #" + ticket.TicketId + "</b></td>" +
                        "</tr>" +
                        "<tr class='bg-lightgrey'>" +
                            "<td colspan='2'><b class='pd-l'>Assunto: </b> " + ticket.Subject + "</td>" +
                        "</tr>" +
                        "<tr class='bg-lightgrey tx-center' style='border-bottom:1px solid;'>" +
                            "<td><b class='pd-l' style='width:50%;'>Enviado Por: </b>" + sender.FirstName + (string.IsNullOrWhiteSpace(sender.LastName) ? "" : " " + sender.LastName) + "</td>" +
                            "<td><b class='pd-l' style='width:50%;'>Data e Hora: </b>" + message.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss") + "</td>" +
                        "</tr>" +
                    "</tbody>" +
                "</table>" +
                "<table style='/* margin-top: .2em; */'>" +
                    "<tbody>" +
                        "<tr style='text-align: center;'>" +
                            "<td style='border: 1px solid black;border-top: 0;border-bottom: 0;'><b>Mensagem</b></td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td class='pd-l' style='border: 1px solid black; border-top: 0; border-radius: 0px 0px 10px 10px; '>" + message.Text + "</td>" +
                        "</tr>" +
                    "</tbody>" +
                "</table>" +
            "</div>";
        }
        #endregion

        #region [PAGES]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(int id)
        {
            return View(id);
        }
        #endregion

        #region [ViewComponent]
        public IActionResult MessageIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Message.MessageIndexViewComponent));
        }
        public IActionResult MessageManageComponent(int id)
        {
            return ViewComponent(typeof(ViewComponents.Message.MessageManageViewComponent), new { id });
        }
        #endregion

        #region [XHR]
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();

            IEnumerable<DTO.Message.MessageListViewModel> d = messageFunctions.GetDataListViewModel(messageFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("SendMessage")]
        public async Task<IActionResult> SendMessage(DTO.Message.MessageViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            var ticket = ticketFunctions.GetDataByID(model.TicketId);

            model.From = user.Id;
            if (model.ReferencedMessageId.HasValue)
            {
                var referenceMessage = messageFunctions.GetDataByID(model.ReferencedMessageId);
                model.To = referenceMessage.From;
            }

            int? to = null;
            if (User.IsInRole("Administrator")) to = ticket.OwnerId;
            else if (User.IsInRole("Client")) to = ticket.AttendentId;

            model.To = to;
            model.MessageId = messageFunctions.Create(model);
            ticketHistoryFunctions.Create(ticketFunctions.GetDataViewModel(ticket), model, FUNCTIONS.Ticket.DBActionType.NEWMESSAGE);

            if (to.HasValue)
            {
                var receive = userFunctions.GetDataByID(to);
                var htmlText = GetNewMessageTextEmail(messageFunctions.GetDataByID(model.MessageId), ticket, user, receive, out List<LinkedResource> linkedResources);

                await FUNCTIONS.Mail.MailFunctions.SendAsync("Nova Mensagem - Ticket #" + model.TicketId, htmlText, GetNewMessageStyleEmail(), new List<string> { receive.Email }, null, linkedResources);
            }
            return RedirectToAction("Message", "Ticket", new { id = model.TicketId, MessageSended = true });
        }

        #endregion
    }
}