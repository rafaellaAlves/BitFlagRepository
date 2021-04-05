using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mime;
using System.Linq;
using BLL.EmailLog;

namespace BLL.Mail
{
    public class MailFunctions
    {
        public static string BioteraLogoImagePath
        {
            get
            {
                return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Assets", "Images", "biotera_logo.jpg");
            }
        }

        private readonly EmailLogFunctions emailLogFunctions;

        public MailFunctions(EmailLogFunctions emailLogFunctions)
        {
            this.emailLogFunctions = emailLogFunctions;
        }

        public async Task SendAsync(string title, string htmlTable, List<string> mailAddress, int? companyId = null, int? userId = null, bool saveLog = true, List<string> replyTo = null, List<string> bcc = null, bool useImage = true)
        {
            int? emailLogId = null;
            if (saveLog)
                emailLogId = await emailLogFunctions.Create(mailAddress, title, htmlTable, companyId, userId);

            try
            {
                //#if DEBUG
                //                SmtpClient smtpClient = new SmtpClient()
                //                {
                //                    Host = "smtp.chokosys.com.br",
                //                    UseDefaultCredentials = false,
                //                    Port = 587,
                //                    Credentials = new NetworkCredential("no-reply@chokosys.com.br", "F3~7eHKbSs\"KC9#w")
                //                };

                //                MailMessage mailMessage = new MailMessage
                //                {
                //                    IsBodyHtml = true,
                //                    From = new MailAddress("no-reply@chokosys.com.br", "GLAS2")
                //                };
                //#else
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.biotera.com.br",
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("sistema@biotera.com.br", "5!9C8@sr")
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress("sistema@biotera.com.br", "GLAS2")
                };
                //#endif

                mailMessage.Subject = "GLAS2 - " + title;

#if !DEBUG
                if (mailAddress != null)
                {
                    foreach (var mail in mailAddress)
                    {
                        if (mailMessage.To.Select(x => x.Address).Contains(mail)) continue;
                        mailMessage.To.Add(mail);
                    }
                }
                
                if (replyTo != null) replyTo.ForEach(x => mailMessage.ReplyToList.Add(x));
                if (bcc != null) bcc.ForEach(x => mailMessage.Bcc.Add(x));
#endif

#if DEBUG
                mailMessage.Subject = "[TESTE] GLAS2 - " + title;
                //mailMessage.Bcc.Add("yuri.santana@bitflag.systems");
                mailMessage.Bcc.Add("sarah.reggiani@bitflag.systems");
                //mailMessage.Bcc.Add("lucas.araujo@bitflag.systems");
#else
                mailMessage.Bcc.Add("glas@biotera.com.br");
                mailMessage.Bcc.Add("yuri.santana@bitflag.systems");
#endif

                string _htmlTable =
                        "<html>" +
                        "<head>" +
                        "<style type='text/css'> " +
                        GetEmailStyles() +
                        "</style>" +
                        "</head>" +
                        "<body>" +
                        (
                            !useImage ? "" :
                            "<div style='text-align:center;'>" +
                            "<img src=\"cid:BioteraLogo\">" +
                            "</div>"
                        ) +
                        "<div style='text-align:center;'>" +
                        htmlTable +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlTable, null, MediaTypeNames.Text.Html);
                //var bioteraLogoFilePath = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "System", "biotera_logo.jpg");
                LinkedResource pic1 = new LinkedResource(BioteraLogoImagePath, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "BioteraLogo";
                htmlView.LinkedResources.Add(pic1);
                mailMessage.AlternateViews.Add(htmlView);

//#if !DEBUG
                await smtpClient.SendMailAsync(mailMessage);
//#endif
            }
            catch (Exception e)
            {
                if (emailLogId.HasValue)
                    await emailLogFunctions.NotSended(emailLogId.Value);
            }
        }

        public static string GetEmailStyles()
        {
            return
                ".table-square {" +
                    "border: 1px solid #333;" +
                    "border-collapse: separate;" +
                    "border-spacing: 0;" +
                    "empty-cells: show;" +
                    "box-shadow: 0px 3px 3px 3px #ccc;" +
                "}" +
                ".table-rounded {" +
                    "border: 1px solid #333;" +
                    "border-collapse: separate;" +
                    "border-spacing: 0;" +
                    "empty-cells: show;" +
                    "border-radius: 5px;" +
                    "box-shadow: 0px 3px 3px 3px #ccc;" +
                "}" +
                ".table-top-rounded {" +
                    "border: 1px solid #333;" +
                    "border-collapse: separate;" +
                    "border-spacing: 0;" +
                    "empty-cells: show;" +
                    "border-radius: 5px 5px 0px 0px ;" +
                "}" +
                ".table-bottom-rounded {" +
                    "border: 1px solid #333;" +
                    "border-collapse: separate;" +
                    "border-spacing: 0;" +
                    "empty-cells: show;" +
                    "border-radius: 0px 0px 5px 5px ;" +
                "}";
        }
    }
}
