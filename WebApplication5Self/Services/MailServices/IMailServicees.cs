
using WebApplication5Self.Model;

namespace WebApplication5Self.Services.MailServices;

public interface IMailServicees
{
    Task SendMail(MailMessage Message);
    
}