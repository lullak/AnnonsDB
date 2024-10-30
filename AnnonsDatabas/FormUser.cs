using AnnonsDatabas.Classes;
using AnnonsDatabas.Entities;
using AnnonsDatabas.Repository;

namespace AnnonsDatabas
{
    public partial class FormUser : Form
    {
        private AccountRepo accountRepo;
        private FormAdvertisments formAdvertisments;
        public FormUser()
        {
            InitializeComponent();
            accountRepo = new AccountRepo();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            // Fetch the account from the database
            Account account = accountRepo.GetByUsername(username);

            // Check if account exists and password is correct
            if (account != null && account.UserPassword == password)
            {
                UserManager.LoggedInUser = account; // Keep track of the logged-in user
                MessageBox.Show("Du är inloggad!");

                FormAdvertisments formAdvertisments = new FormAdvertisments();
                formAdvertisments.RefreshUserStatus(); // Update the main form with the logged-in user
                this.Hide();
                formAdvertisments.Show(); // Show the main form
            }
            else
            {
                MessageBox.Show("Ogiltig användarnamn eller lösenord.");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim(); // Assuming you have a TextBox for username
            string password = textBoxPassword.Text.Trim(); // Assuming you have a TextBox for password

            // Create a new account
            Account newAccount = new Account(0, username, password); // ID will be set by the database

            if (accountRepo.Register(newAccount))
            {
                MessageBox.Show("Du är nu registrerad!");

            }
            else
            {
                MessageBox.Show("Användarnamn upptagen.");
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            UserManager.LoggedInUser = null; // Log out the user
           // UpdateLoggedInUserLabel(); // Update the label after logout
            MessageBox.Show("Du är nu utloggad."); 
            FormAdvertisments formAdvertisments = new FormAdvertisments();
            formAdvertisments.RefreshUserStatus(); // Update the main form with the logged-in user
            this.Hide();
            formAdvertisments.Show();
        }
    }
}
