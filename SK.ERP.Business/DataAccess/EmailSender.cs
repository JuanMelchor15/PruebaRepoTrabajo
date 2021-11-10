using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;
using SK.ERP.Business.DataAccess.Interfaces;
using SK.ERP.Entities.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SK.ERP.Business.DataAccess
{
    public class EmailSender : IEmailSender
    {
        private readonly IHostingEnvironment _webHostEnvironment;
        private readonly ILogger _Logger;

        private readonly EmailOptions _emailOptions;

        public EmailSender(EmailOptions emailOptions, IHostingEnvironment webHostEnvironment, ILoggerFactory logger)
        {
            _emailOptions = emailOptions;
            _webHostEnvironment = webHostEnvironment;
            _Logger = logger.CreateLogger<EmailSender>();
        }

        public void SendEmail(MessageEmail message)
        {
            //if (_emailOptions.FlgSendMail)
            //{
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
            //}
        }

        private void OnMessageSent(object sender, MessageSentEventArgs e)
        {
            //_Logger.LogWarning("The message was sent!");
        }

        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    var To = emailMessage.To;

                    if (!_emailOptions.IsRelay)
                    {
                        client.Connect(_emailOptions.SmtpServer, _emailOptions.Port, _emailOptions.ServerSSL);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        client.Authenticate(_emailOptions.UserName, _emailOptions.Password);

                        client.MessageSent += OnMessageSent;
                        client.Send(emailMessage);
                    }
                    else
                    {
                        client.Connect(_emailOptions.SmtpServer, _emailOptions.Port, MailKit.Security.SecureSocketOptions.None);
                        client.MessageSent += OnMessageSent;
                        client.Send(emailMessage);
                    }
                }
                catch (Exception ex)
                {
                    _Logger.LogWarning(string.Format("ERROR AL ENVIAR CORREO {0:dd-MM-yyyy:hh:mm:ss} - " + ex.Message, DateTime.Now));
                    throw ex;
                }
                finally
                {
                    //_Logger.LogWarning("ENTRO FINALLY CORREO");
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(MessageEmail message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailOptions.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var HtmlTemplate = string.Empty;
            switch (message.TypeTemplate)
            {
                //case eTypeTemplate.NotificacionAutorizacion:
                //    HtmlTemplate = _emailOptions.TemplateNotificacion;
                //    break;
            }

            var HmtlFile = HtmlTemplate;
            var HtmlPath = Path.Combine(_webHostEnvironment.WebRootPath, HmtlFile);
            var msg = File.ReadAllText(HtmlPath);

            //msg = msg.Replace("@CONSULTOR", $"{message.DocumentEntity.Consultor}");
            //msg = msg.Replace("@TITULO", $"{message.DocumentEntity.Titulo}");
            //msg = msg.Replace("@OBJETIVO", $"{message.DocumentEntity.Objetivo}");
            //msg = msg.Replace("@URLAUTORIZACION", $"{message.DocumentEntity.UrlAutorizacion}");
            //msg = msg.Replace("@URLCONSULTA", $"{message.DocumentEntity.UrlConsulta}");
            //msg = msg.Replace("@URLCOMENTARIO", $"{message.DocumentEntity.UrlComentario}");

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = msg
            };

            return emailMessage;
        }
    }
}
