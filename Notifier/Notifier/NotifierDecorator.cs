namespace Notifier
{
    internal abstract class NotifierDecorator : INotifier
    {
        protected INotifier _notifier;

        public NotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message, List<User> users, string role = null, string recipientName = null)
        {
            _notifier.Send(message, users, role, recipientName);
        }
    }

}
