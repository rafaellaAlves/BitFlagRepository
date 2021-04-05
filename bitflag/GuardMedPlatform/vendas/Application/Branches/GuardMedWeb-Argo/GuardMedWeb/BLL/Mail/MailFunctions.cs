using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mime;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BLL.Mail
{
    public class MailFunctions
    {
        IConfiguration configuration;

        public MailFunctions(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendAsync(string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments, bool useContact = false)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.chokosys.com.br",
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("no-reply@chokosys.com.br", "F3~7eHKbSs\"KC9#w")
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress("no-reply@chokosys.com.br", "Vendas - GuardMed")
                };

                mailMessage.Subject = title;

                if (configuration.GetValue<bool>("IsHomolog"))
                {
                    mailMessage.To.Add("denis@amaisseg.com.br");
                    mailMessage.To.Add("rpetrilli@guardmed.com.br");
                    if (mailAddresses != null)
                        foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);
                }
                else
                {
#if DEBUG
                    mailMessage.To.Add("yuri.santana@bitflag.systems");
                    mailMessage.To.Add("sarah.reggiani@bitflag.systems");
#else
                if (mailAddresses != null)
                    foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);

                    mailMessage.Bcc.Add("sarah.reggiani@bitflag.systems");

                if (useContact)
                    mailMessage.Bcc.Add("contato@guardmed.com.br");
#endif
                }

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:Logo\" width='300' >" +
                        "</div>" +
                        "<div>" +
                        htmlContent +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
                var currentDirectory = Directory.GetCurrentDirectory();
                if (attachments != null)
                    foreach (var attachment in attachments)
                        mailMessage.Attachments.Add(attachment);
                var imgDirectory = Path.Combine(currentDirectory, "wwwroot", "images", "GuardMedLogo.png");
                LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "Logo";
                htmlView.LinkedResources.Add(pic1);
                mailMessage.AlternateViews.Add(htmlView);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception e)
            {

            }
        }


        public void Send(string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments, bool useContact = false)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "mail.guardmed.com.br",
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("contato@guardmed.com.br", "contatoGM#20")
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress("contato@guardmed.com.br", "Vendas - GuardMed")
                };

                mailMessage.Subject = title;

                if (configuration.GetValue<bool>("IsHomolog"))
                {
                    mailMessage.To.Add("denis@amaisseg.com.br");
                    mailMessage.To.Add("rpetrilli@guardmed.com.br");
                }
                else
                {
                    if (mailAddresses != null)
                        foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);

                    if (useContact)
                    {
                        mailMessage.ReplyToList.Add(new MailAddress("contato@guardmed.com.br", "Vendas - GuardMed"));
                        mailMessage.Bcc.Add("contato@guardmed.com.br");
                        mailMessage.Bcc.Add("yuri.santana@bitflag.systems");
                    }
                }

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:Logo\" width='300' >" +
                        "</div>" +
                        "<div>" +
                        htmlContent +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
                var currentDirectory = Directory.GetCurrentDirectory();
                if (attachments != null)
                    foreach (var attachment in attachments)
                        mailMessage.Attachments.Add(attachment);
                var imgDirectory = Path.Combine(currentDirectory, "wwwroot", "images", "GuardMedLogo.png");
                LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "Logo";
                htmlView.LinkedResources.Add(pic1);
                mailMessage.AlternateViews.Add(htmlView);

                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {

            }
        }
    }
}
