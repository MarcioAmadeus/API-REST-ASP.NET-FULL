using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace LEGITIM.DISTRIBUIDORA.Web.Utils.Mail
{
    public class MailHelper
    {

        private const string EMAILREMETENTE = "aulavbafgv@gmail.com";
        private const string SENHAREMETENTE = "Fgv@1234";

        public bool EnviarEmail(string EmailDestinatario, string NomeDestinatario, string Assunto, string Corpo, string path)
        {
            //string bodyTest = System.IO.File.ReadAllText("C:/Users/Amadeus/Desktop/email_FGV_HTML.html");
            //Email de remetende
            //aulavbafgv@gmail.com
            //Fgv@1234
#if DEBUG
            EmailDestinatario = "marcioamadeus@gmail.com";
#endif
            var fromAddress = new MailAddress(EMAILREMETENTE, "Notificação do sistema de gestão");
            const string fromPassword = SENHAREMETENTE;
            var toAddress = new MailAddress(EmailDestinatario, NomeDestinatario);
            string body = Corpo;
            DateTime now = DateTime.Now;
            //DateTime modifiedDatetime = now.AddMonths(2);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };
           

            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = Assunto,
                Body = Corpo
            };
            message.IsBodyHtml = true;

        

            if (path != null)
            {
                var attachmentFilename = "test";
                if (attachmentFilename != null)
                {
                    Attachment attachment;
                    var diminio = System.Web.HttpContext.Current.Server.MapPath("~/Content/kitSunmissao/");
                    string pathCompleto = diminio + path;
                    attachment = new System.Net.Mail.Attachment(pathCompleto);
                    message.Attachments.Add(attachment);
                }
            }


            try
                {
                    smtp.Send(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Email não pode ser enviado:\n", e);
                    return false;
                }
            return true;
        }
    }
}