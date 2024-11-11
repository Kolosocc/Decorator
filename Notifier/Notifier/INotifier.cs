namespace Notifier
{
    internal interface INotifier
    {
        void Send(string message, List<User> users, string role = null, string recipientName = null);
    }
}
