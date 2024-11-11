namespace Notifier
{
    internal class FacebookNotifier : NotifierDecorator
    {
        public FacebookNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message, List<User> users, string role = null, string recipientName = null)
        {
            base.Send(message, users, role, recipientName);

            foreach (var user in users)
            {
                if ((role == null || user.Role == role) &&
                    (recipientName == null || user.Name == recipientName) &&
                    user.PreferredNotifiers.Contains(NotifierType.Facebook))
                {
                    Console.WriteLine($"Отправка Facebook-сообщения для {user.Name} ({user.Role}) на аккаунт {user.FacebookAccount}: {message}");
                }
            }
        }
    }
}

