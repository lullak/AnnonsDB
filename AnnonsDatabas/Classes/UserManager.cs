using AnnonsDatabas.Entities;

namespace AnnonsDatabas.Classes
{
    public static class UserManager
    {
        public static Account LoggedInUser { get; set; }

        public static void Logout()
        {
            LoggedInUser = null;
        }
    }
}
