using System;

namespace Hospital.Utils
{
    public class EmailService
    {
        // Stubbed email sender - replace with SMTP or external provider in real project.
        public void SendEmail(string to, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(to)) throw new ArgumentException("No recipient");
            // Simulate send
            Console.WriteLine($"[EmailService] Sending to {to}: {subject}");
        }
    }
}
