using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace JTTT
{
    public static class MailSender
    {
        private static readonly MailAddress FromAddress;
        private static readonly string Password;
        private static readonly string Subject;
        private static readonly SmtpClient SmtpClient;



        static MailSender()
        {
            FromAddress = new MailAddress("spambotT1000@gmail.com", "bot");
            Password = "jtttT1000";
            Subject = "Subject";
            SmtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromAddress.Address, Password)
            };
        }

        private static void SendMail(string body, string email)
        {
            var toAddress = new MailAddress(email, "Master");

            using (var message = new MailMessage(FromAddress, toAddress)
            {
                Subject = Subject,
                Body = body
            })
            {
                SmtpClient.Send(message);
            }
        }

        public static void SendAllNodes(IEnumerable<HtmlNode> nodes, string email)
        {
            var src = nodes.Select(n => n.GetAttributeValue("src", "")).ToArray();
            var message = String.Join("\n", src);

            SendMail(message, email);      
        }
    }
}
