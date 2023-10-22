using System.Net;
using System.Net.Mail;

namespace LarimalTravel
{
    public class CEnvioDeEmailPorGmail
    {
        public string from { set; get; }
        public string password { set; get; }

        public CEnvioDeEmailPorGmail(string from, string password)
        {
            this.from = from;
            this.password = password;
        }

        public void EnviarCorreo(string to, string subject, string message)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = subject;
            msg.From = new MailAddress(from);
            msg.Body = message;
            msg.To.Add(new MailAddress(to));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; // Corrected SMTP server address
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential(from, password);
            smtp.Credentials = nc;

            try
            {
                smtp.Send(msg);
                Console.Write("Email sent successfully");
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., display an error message or log the error)
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
