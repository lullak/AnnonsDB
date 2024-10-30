using AnnonsDatabas.Classes;
using AnnonsDatabas.Entities;
using AnnonsDatabas.Repository;
using System.Globalization;
using System.Windows.Forms;

namespace AnnonsDatabas
{
    public partial class FormAdvertisments : Form
    {

        public FormAdvertisments()
        {
            InitializeComponent();
            LoadCategories();
            LoadAdverts();
        }

        public void UpdateLoggedInUserLabel()
        {
            if (UserManager.LoggedInUser != null)
            {
                labelLoggedInStatus.Text = $"Logged in as: {UserManager.LoggedInUser.Username}";
            }
            else
            {
                labelLoggedInStatus.Text = "ej inloggad"; // Display when no user is logged in
            }
        }

        public void RefreshUserStatus()
        {
            UpdateLoggedInUserLabel();
        }
        private void LoadCategories()
        {
            CategoryRepo repo = new CategoryRepo();
            var categories = repo.GetList();

            comboBoxCategories.DisplayMember = "CategoryName";
            comboBoxCategories.ValueMember = "Id";
            comboBoxCategories.DataSource = categories;

            comboBoxCategories.SelectedIndex = -1;
        }
        private void LoadAdverts(string sortBy = "CreatedDate")
        {
            AdvertisementRepo repo = new AdvertisementRepo();

            int? selectedCategoryId = comboBoxCategories.SelectedValue as int?;

            if (comboBoxCategories.SelectedValue != null && int.TryParse(comboBoxCategories.SelectedValue.ToString(), out int categoryId))
            {
                selectedCategoryId = categoryId;
            }

            var adverts = repo.GetList(sortBy, selectedCategoryId);

            listBoxAds.DisplayMember = "ToString";
            listBoxAds.ValueMember = "Id";
            listBoxAds.DataSource = adverts;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text.Trim(); // Get the search term from the TextBox
            int? selectedCategoryId = comboBoxCategories.SelectedValue as int?; // Get the selected category ID

            AdvertisementRepo repo = new AdvertisementRepo();

            // Call GetList with the search parameters
            var filteredAdvertisements = repo.SearchAdvertisements(searchTerm, selectedCategoryId);

            // Update the ListBox with the filtered results
            listBoxAds.DataSource = new BindingSource { DataSource = filteredAdvertisements };
            listBoxAds.DisplayMember = "ToString"; // or however you want to display it
            listBoxAds.ValueMember = "Id"; // assuming this is the ID of the advertisement
        }

        private void buttonPriceSort_Click(object sender, EventArgs e)
        {
            LoadAdverts("Price");
        }

        private void buttonDateSort_Click(object sender, EventArgs e)
        {
            LoadAdverts("CreatedDate");
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdverts();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = string.Empty;
            LoadCategories();
            LoadAdverts();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            FormUser formUser = new FormUser();
            formUser.Show();
            this.Hide();
        }
    }
}
