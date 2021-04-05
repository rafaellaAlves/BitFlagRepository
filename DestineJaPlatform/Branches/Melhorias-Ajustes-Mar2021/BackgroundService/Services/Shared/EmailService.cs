using DTO.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace BackgroundService.Services.Shared
{
    public abstract class EmailService<T> : TimedHostedService
    {
        public string Site { get; }

        public EmailService(ILogger<TimedHostedService> logger, IConfiguration iConfiguration, float delayHour = 24)
            : base(logger, iConfiguration, delayHour)
        {

#if DEBUG
            Site = iConfiguration.GetValue<string>("Site:Development");
#else
            Site = iConfiguration.GetValue<string>("Site:Prod");
#endif
        }

        public override void DoWork(object state)
        {
            try
            {
                foreach (var item in GetItems())
                    SendEmail(item, GetSubject(item), GetEmail(item));
            }
            catch { }
        }

        public abstract List<T> GetItems();
        public abstract string GetSubject(T entity);
        public abstract List<string> GetEmail(T entity);
        public abstract string GetEmailTextBody(T entity);

        public string GetEmailText(T entity)
        {
            return "<div style=\"max-width: 500px; margin-left: auto; margin-right: auto; padding: 15px; border: 1px solid #bbbbbb; background-color: #f1f1f152;\">" +
            "<div style=\"width:100%; text-align: center; margin-bottom: 3em;\">" +
                "<img style=\"width:400px;\" src=\"cid:Logo\" />" +
            "</div>" +
           GetEmailTextBody(entity) +
            "<div style=\"font-size: 14px;\">" +
                "Atenciosamente," +
                "<br />" +
                "Equipe Destine Já." +
            "</div>" +
        "</div>";
        }

        public void SendEmail(T entity, string subject, string email) => SendEmail(entity, subject, new List<string> { email });

        public void SendEmail(T entity, string subject, List<string> emails, List<string> replyTo = null, List<string> bcc = null) => emailServices.Send(subject, GetEmailText(entity), emails, replyTo, bcc, null, new List<LinkedResource> { new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg) { ContentId = "Logo" } }, false);
    }
}
