using System.Net;
using System.Net.Mail;

public static class EmailSender
{
    public static bool SendEmail(string toEmail, string subject, string body)
    {
        try
        {
            var fromEmail = "valecade16@gmail.com";  // Tu email de Gmail
            var fromPassword = "yeodsegcvufihxte";   // Tu contraseña de aplicación sin espacios

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,  // Puerto SMTP para Gmail
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true,  // Seguridad
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = false,  
            };

            mailMessage.To.Add(toEmail);

            smtpClient.Send(mailMessage);

            return true; 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al enviar correo: " + ex.Message);
            return false;  
        }
    }
}