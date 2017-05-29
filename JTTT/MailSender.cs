using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using MimeKit;
using MailKit.Net.Smtp;

namespace JTTT
{
    public static class MailSender
    {
        private static void SendMail(string subject, string body, string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("JTTTSpam", "jttt.net@wp.pl"));
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.wp.pl", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("jttt.net", "jttt.NET");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static void SendAllNodes(IEnumerable<HtmlNode> nodes, string email)
        {
            var src = nodes.Select(n => n.GetAttributeValue("src", "")).ToList();

            var body = "";
            foreach (var node in src)
            {
                body += "<img src=\"" + node + "\" /><br />";
            }

            var subject = "JTTT - znalezione obrazki";

            SendMail(subject, body, email);
        }
    }
}
