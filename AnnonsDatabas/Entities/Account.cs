namespace AnnonsDatabas.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }

        public Account(int id, string username, string userPassword)
        {
            Id = id;
            Username = username;
            UserPassword = userPassword;
        }
    }
}
