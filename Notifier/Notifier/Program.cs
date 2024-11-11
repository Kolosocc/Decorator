using Notifier;

internal class Program
{
    static void Main(string[] args)
    {
        var users = new List<User>
        {
            new User(email: "admin@example.com", name: "Алексей", role: "admin", preferredNotifiers: new List<NotifierType> { NotifierType.Email, NotifierType.Facebook }),
            new User(phoneNumber: "+0987654321", name: "Иван", role: "sysadmin", preferredNotifiers: new List<NotifierType> { NotifierType.SMS }),
            new User(facebookAccount: "userFBAccount", name: "Мария", role: "user", preferredNotifiers: new List<NotifierType> { NotifierType.Facebook, NotifierType.SMS }),
            new User(email: "user2@example.com", phoneNumber: "+1122334455", preferredNotifiers: new List<NotifierType> { NotifierType.Email, NotifierType.SMS })
        };


        INotifier notifier = new EmailNotifier();

        notifier = new SMSNotifier(notifier);
        notifier = new FacebookNotifier(notifier);

        Console.WriteLine("Уведомления всем пользователям:");
        notifier.Send("Доступно новое обновление системы.", users);


        Console.WriteLine("\nУведомления конкретному пользователю:");
        notifier.Send("Ваш пароль скоро истекает. Обновите его.", users, "user", "Мария");
    }
}


