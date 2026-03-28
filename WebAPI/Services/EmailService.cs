using MailKit.Net.Smtp;
using MimeKit;
namespace WebAPI.Services;

public class EmailService
{
    // Dependency injection to access existing email settings in appsettings.json
    private readonly IConfiguration _config;

    // Builder settings for receiving emails
    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var message = new MimeMessage(); //Create a new email message

        message.From.Add(new MailboxAddress(_config["EmailSettings:Name"], _config["EmailSettings:Email"])); // define the sender's email address and name
     
        message.To.Add(MailboxAddress.Parse(toEmail)); // define the recipient's email address

        message.Subject = subject; // set the email subject

        message.Body = new TextPart("html") { Text = body }; // set the email body as plain text

        using var client = new SmtpClient(); // create a new SMTP client

        await client.ConnectAsync(_config["EmailSettings:Host"], int.Parse(_config["EmailSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls); // connect to the SMTP server using the host and port from the _config

        await client.AuthenticateAsync(_config["EmailSettings:Email"], _config["EmailSettings:Password"]); // authenticate with the SMTP server using the email and password from the _config

        await client.SendAsync(message); //send the email message

        await client.DisconnectAsync(true); // disconnect from the SMTP server
    }
}
