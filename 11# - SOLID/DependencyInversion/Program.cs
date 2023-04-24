using DependencyInversion;

Console.WriteLine("D - Dependency Inversion Principle");

INotificationSender emailSender = new EmailSender();
NotificationService notificationService = new NotificationService(emailSender);

string message = "Sample notification message";
notificationService.SendNotification(message);