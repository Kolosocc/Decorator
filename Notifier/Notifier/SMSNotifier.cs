namespace Notifier
{
    internal class SMSNotifier : NotifierDecorator
    {
        public SMSNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message, List<User> users, string role = null, string recipientName = null)
        {
            base.Send(message, users, role, recipientName);

            foreach (var user in users)
            {
                if ((role == null || user.Role == role) &&
                    (recipientName == null || user.Name == recipientName) &&
                    user.PreferredNotifiers.Contains(NotifierType.SMS))
                {
                    Console.WriteLine($"Отправка SMS для {user.Name} ({user.Role}) на номер {user.PhoneNumber}: {message}");
                }
            }
        }


    }
}
