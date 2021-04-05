using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;


namespace Services.Email
{
    public class EmailServices
    {
        private readonly IConfiguration configuration;
        private readonly EmailLogServices emailLogServices;

        public EmailServices(IConfiguration configuration, EmailLogServices emailLogServices)
        {
            this.configuration = configuration;
            this.emailLogServices = emailLogServices;
        }

        public bool Send(string title, string htmlContent, List<string> to, List<string> replyTo = null, List<string> bcc = null, List<Attachment> attachments = null, List<LinkedResource> resources = null, bool useInitialImage = true, bool forceSend = false)
        {
            int emailLogId;

            if (!configuration.GetValue<bool>("Emails:SendEmails"))
            {
                emailLogServices.Create(to, replyTo, bcc, title, false, "Trava do sistema \"Emails:SendEmails\"");

                return false;
            }

            emailLogId = emailLogServices.Create(to, replyTo, bcc, title);

            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.chokosys.com.br",
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential(configuration.GetValue<string>("Emails:Credentials:UserName"), configuration.GetValue<string>("Emails:Credentials:Password"))
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress(configuration.GetValue<string>("Emails:Credentials:UserName"), "Destine Já")
                };

                mailMessage.Subject = $"{title}";

#if DEBUG
                mailMessage.Bcc.Add("sarah.reggiani@bitflag.systems");
                //mailMessage.Bcc.Add("lucas.araujo@bitflag.systems");
#else
                if (to != null) to.ForEach(x => mailMessage.To.Add(x));
                if (replyTo != null) replyTo.ForEach(x => mailMessage.CC.Add(x));
                if (bcc != null) bcc.ForEach(x => mailMessage.Bcc.Add(x));

                mailMessage.Bcc.Add("naoresponda@destineja.com.br");
#endif

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        (useInitialImage ? "<div style='text-align:center;'><img height=\"150\" src=\"cid:InitialLogo\" \\></div>" : "") +
                        "<div>" +
                        "<br/><br/>" +
                        htmlContent +
                        "</div>" +
                        "<div style=\"text-align: center;margin-top: 50px;margin-bottom: 50px;\"><a href=\"mailto:contato@destineja.com.br\" style=\"color: white; background: #04ab9f; text-decoration: none; padding: 15px; border-radius: 7px;\">Clique aqui para responder esta mensagem</a></div>" +
                        "</body>" +
                        "</html>";

                if (attachments != null) attachments.ForEach(x => mailMessage.Attachments.Add(x));

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
                if (useInitialImage)
                {
                    LinkedResource pic1 = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg);
                    pic1.ContentId = "InitialLogo";
                    htmlView.LinkedResources.Add(pic1);
                }
                if (resources != null) resources.ForEach(x => htmlView.LinkedResources.Add(x));

                mailMessage.AlternateViews.Add(htmlView);
#if !DEBUG
                smtpClient.Send(mailMessage);
#endif

                return true;
            }
            catch (Exception e)
            {
                emailLogServices.InsertError(emailLogId, e.Message);

                return false;
            }
        }
    }
}
