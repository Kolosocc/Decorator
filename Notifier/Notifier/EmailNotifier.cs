using Notifier;

internal class EmailNotifier : INotifier
{
    public void Send(string message, List<User> users, string role = null, string recipientName = null)
    {
        foreach (var user in users)
        {
            if ((role == null || user.Role == role) &&
                (recipientName == null || user.Name == recipientName) &&
                user.PreferredNotifiers.Contains(NotifierType.Email))
            {
                Console.WriteLine($"Отправка Email для {user.Name} ({user.Role}) на {user.Email}: {message}");
            }
        }
    }
}