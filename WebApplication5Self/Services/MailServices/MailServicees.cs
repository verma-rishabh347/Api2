using System.Net.Mail;
using MailKit;
using MimeKit;
using WebApplication5Self.Services.GenerateOTP;
using WebApplication5Self.Services.MailServices;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using MailMessage1 = WebApplication5Self.Model.MailMessage;

public class MailServicees : IMailServicees
{
    private readonly IConfiguration _configuration;
    private readonly IOtpService _otpService;

    public MailServicees(IConfiguration configuration, IOtpService otpService)
    {
        _configuration = configuration;
        _otpService = otpService;
    }

    public async Task SendMail(MailMessage1 mail)
    {
        var from = _configuration["EmailSettings:From"];
        var password = _configuration["EmailSettings:Password"];
        var port = _configuration.GetValue<int>("EmailSettings:Port");
        var host = _configuration["EmailSettings:Host"];

        var fromMail = new MailboxAddress("Rishabh", from);
        
        var message = new MimeMessage();
        message.From.Add(fromMail);

        message.To.Add(MailboxAddress.Parse(mail.To));
     

        message.Subject = mail.Subject;

        message.Body = new TextPart("html")
        {
            Text = mail.Body
        };

        using var client = new SmtpClient();

        await client.ConnectAsync(host, port, MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(from, password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}