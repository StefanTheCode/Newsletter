namespace DependencyInversion;

public interface INotificationSender
{
    void SendNotification(string message);
}