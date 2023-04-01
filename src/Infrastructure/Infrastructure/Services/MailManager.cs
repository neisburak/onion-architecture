using Application.Common.Interfaces;
using Application.Common.Models;

namespace Infrastructure.Services;

public class MailManager : IMailService
{
    public void Send(MailForSend mailForSend)
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(MailForSend mailForSend, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
