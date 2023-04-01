using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IMailService
{
    void Send(MailForSend mailForSend);
    Task SendAsync(MailForSend mailForSend, CancellationToken cancellationToken = default);
}
