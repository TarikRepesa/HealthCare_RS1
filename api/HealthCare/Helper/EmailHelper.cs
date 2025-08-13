using System.Net;
using System.Net.Mail;

namespace HealthCare.Helper
{
    public static class EmailHelper
    {
        private static readonly string fromAddress = "healthcaretest190@gmail.com";
        private static readonly string mailPassword = "lkdnnoyxqqekzfsc";
        private static readonly string fromSenderName = "HealthCare.NET";
        public static bool SendMail(string subject, string body, string toAddress)
        {
            toAddress = fromAddress; // For testing purposes

            try
            {
                MailMessage message = new()
                {
                    From = new MailAddress(fromAddress, fromSenderName),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body,
                };
                message.To.Add(new MailAddress(toAddress));

                SmtpClient smtp = new()
                {
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress, mailPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                smtp.Send(message);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
