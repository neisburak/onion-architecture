using Application.Interfaces;

namespace Infrastructure.Services;

public class SystemClockManager : ISystemClock
{
    public DateTime Now => DateTime.UtcNow;
}