namespace Application.Common.Interfaces;

public interface ISystemClock
{
    DateTime Now { get; }
}