using AnnonsDatabas.Classes;
using AnnonsDatabas.Entities;
using AnnonsDatabas.Repository;
using System.Globalization;
using System.Windows.Forms;

namespace AnnonsDatabas
{
    public partial class FormAdvertisments : Form
    {
        private List<Category> _categories;
        public FormAdvertisments()
        {
            InitializeComponent();
            LoadCategories();
            LoadAdverts();
            UpdateButtonVisibility();
        }

        private void UpdateButtonVisibility()
        {
            // Show create button if user is logged in
            buttonCreateAd.Visible = UserManager.LoggedInUser != null;

            // Check if a user is logged in and an ad is selected
            if (UserManager.LoggedInUser != null && listBoxAds.SelectedItem is Advertisement selectedAd)
            {
                // Show edit and delete buttons if the selected ad belongs to the logged-in user
                buttonEditAd.Visible = selectedAd.CreatedBy == UserManager.LoggedInUser.Id;
                buttonDeleteAd.Visible = selectedAd.CreatedBy == UserManager.LoggedInUser.Id;
            }
            else
            {
                // Hide edit and delete buttons if no ad is selected or if the user is not logged in
                buttonEditAd.Visible = false;
                buttonDeleteAd.Visible = false;
            }
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
        public void LoadCategories()
        {
            CategoryRepo repo = new CategoryRepo();
            var categories = repo.GetList();

            comboBoxCategories.DisplayMember = "CategoryName";
            comboBoxCategories.ValueMember = "Id";
            comboBoxCategories.DataSource = categories;

            comboBoxCategories.SelectedIndex = -1;

            _categories = categories;
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

        private void listBoxAds_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonVisibility();
        }

        private void buttonDeleteAd_Click(object sender, EventArgs e)
        {
            if (listBoxAds.SelectedItem is Advertisement selectedAd)
            {
                var result = MessageBox.Show("Are you sure you want to delete this advertisement?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var adRepo = new AdvertisementRepo();
                    adRepo.Delete(selectedAd.Id); // Delete the selected advertisement
                    LoadAdverts(); // Refresh the adverts
                    UpdateButtonVisibility(); // Update button visibility after deletion
                }
            }
        }

        private void buttonCreateAd_Click(object sender, EventArgs e)
        {
            var createForm = new FormEdit(null, _categories); // Pass null for advertisement, and pass categories
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadAdverts(); // Refresh the advertisements list after creation
            }
        }

        private void buttonEditAd_Click(object sender, EventArgs e)
        {
            if (listBoxAds.SelectedItem is Advertisement selectedAd)
            {
                var editForm = new FormEdit(selectedAd, _categories); // Pass the selected advertisement and categories

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAdverts(); // Refresh the advertisements list after editing
                }
            }
            else
            {
                MessageBox.Show("Please select an advertisement to edit.");
            }
        }
    }
}
