using MailKit;
using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Model;
using WebApplication5Self.Services.MailServices;

// using MailMessage = System.Net.Mail.MailMessage;

namespace WebApplication5Self.Controller;

public class MailController:ControllerBase
{
    private readonly IMailServicees _mailServicees;

    public MailController(IMailServicees mailServicees)
    {
        _mailServicees = mailServicees;
    }

    [HttpPost("/api/mail")]
    public async Task<IActionResult> SendEmail(MailMessage message)
    {
        await _mailServicees.SendMail(message);
        return Ok("Sended");
    }
}