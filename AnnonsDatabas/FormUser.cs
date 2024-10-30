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

            Account account = accountRepo.GetByUsername(username);

            if (account != null && account.UserPassword == password)
            {
                UserManager.LoggedInUser = account;
                MessageBox.Show("Du är inloggad!");

                FormAdvertisments formAdvertisments = new FormAdvertisments();
                formAdvertisments.RefreshUserStatus();
                this.Hide();
                formAdvertisments.Show();
            }
            else
            {
                MessageBox.Show("Ogiltig användarnamn eller lösenord.");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            Account newAccount = new Account(0, username, password);

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
            UserManager.LoggedInUser = null;
            MessageBox.Show("Du är nu utloggad."); 
            FormAdvertisments formAdvertisments = new FormAdvertisments();
            formAdvertisments.RefreshUserStatus();
            this.Hide();
            formAdvertisments.Show();
        }
    }
}
