using Application.Common.Interfaces;

namespace Infrastructure.Services;

public class SystemClock : ISystemClock
{
    public DateTime Now => DateTime.UtcNow;
}