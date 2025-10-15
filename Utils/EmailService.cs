using System;

namespace Hospital.Utils
{
    public class EmailService
    {
        private const string ADMIN_EMAIL = "srching23@gmail.com"; // Cambia esto por tu correo

        // Stubbed email sender - replace with SMTP or external provider in real project.
        public void SendEmail(string to, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(to)) throw new ArgumentException("No recipient");
            // Simulate send
            Console.WriteLine($"[EmailService] Sending to {to}: {subject}");
        }

        public void SendEmailWithAdminCopy(string to, string subject, string body)
        {
            // Send to main recipient
            SendEmail(to, subject, body);
            
            // Send copy to admin
            string adminSubject = $"[COPY] {subject}";
            string adminBody = $"Copy of email sent to: {to}\n\n{body}";
            SendEmail(ADMIN_EMAIL, adminSubject, adminBody);
        }
    }
}
