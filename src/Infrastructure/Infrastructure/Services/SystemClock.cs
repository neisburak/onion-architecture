using Application.Interfaces;

namespace Infrastructure.Services;

public class SystemClock : ISystemClock
{
    public DateTime Now => DateTime.UtcNow;
}