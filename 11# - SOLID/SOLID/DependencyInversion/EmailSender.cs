namespace DependencyInversion;

public class EmailSender : INotificationSender
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}