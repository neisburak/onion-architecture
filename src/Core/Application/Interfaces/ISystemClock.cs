namespace Application.Interfaces;

public interface ISystemClock
{
    DateTime Now { get; }
}