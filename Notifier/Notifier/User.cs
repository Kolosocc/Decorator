namespace Notifier
{
    internal class User
    {

        public string Email { get; }
        public string PhoneNumber { get; }
        public string FacebookAccount { get; }
        public string Name { get; }
        public string Role { get; }
        public List<NotifierType> PreferredNotifiers { get; } 

        public User(string email = null, string phoneNumber = null, string facebookAccount = null, string name = null, string role = null, List<NotifierType> preferredNotifiers = null)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(facebookAccount))
            {
                throw new ArgumentException("Хотя бы одно из полей (Email, PhoneNumber или FacebookAccount) должно быть заполнено.");
            }

            Email = email;
            PhoneNumber = phoneNumber;
            FacebookAccount = facebookAccount;
            Name = name;
            Role = role;
            PreferredNotifiers = preferredNotifiers ?? new List<NotifierType> { NotifierType.Email }; 
        }
    }
}
