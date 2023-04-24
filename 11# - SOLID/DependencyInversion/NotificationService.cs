namespace DependencyInversion;

public class NotificationService
{
    private INotificationSender _notificationSender;

    public NotificationService(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }

    public void SendNotification(string message)
    {
        _notificationSender.SendNotification(message);
    }
}