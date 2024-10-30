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
            buttonCreateAd.Visible = UserManager.LoggedInUser != null;

            if (UserManager.LoggedInUser != null && listBoxAds.SelectedItem is Advertisement selectedAd)
            {
                buttonEditAd.Visible = selectedAd.CreatedBy == UserManager.LoggedInUser.Id;
                buttonDeleteAd.Visible = selectedAd.CreatedBy == UserManager.LoggedInUser.Id;
            }
            else
            {
                buttonEditAd.Visible = false;
                buttonDeleteAd.Visible = false;
            }
        }
        private void UpdateLoggedInUserLabel()
        {
            if (UserManager.LoggedInUser != null)
            {
                labelLoggedInStatus.Text = $"Inloggad som: {UserManager.LoggedInUser.Username}";
            }
            else
            {
                labelLoggedInStatus.Text = "Ej inloggad, skapa ett konto genom att klicka på hantera användare!";
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
            string searchTerm = textBoxSearch.Text.Trim();
            int? selectedCategoryId = comboBoxCategories.SelectedValue as int?;

            AdvertisementRepo repo = new AdvertisementRepo();

            var filteredAdvertisements = repo.SearchAdvertisements(searchTerm, selectedCategoryId);

            listBoxAds.DataSource = new BindingSource { DataSource = filteredAdvertisements };
            listBoxAds.DisplayMember = "ToString";
            listBoxAds.ValueMember = "Id";
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
                var result = MessageBox.Show("Är du säker att du vill ta bort annonsen?", "Bekräfta", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var adRepo = new AdvertisementRepo();
                    adRepo.Delete(selectedAd.Id);
                    LoadAdverts();
                    UpdateButtonVisibility();
                }
            }
        }

        private void buttonCreateAd_Click(object sender, EventArgs e)
        {
            var createForm = new FormEdit(null, _categories);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadAdverts();
            }
        }

        private void buttonEditAd_Click(object sender, EventArgs e)
        {
            if (listBoxAds.SelectedItem is Advertisement selectedAd)
            {
                var editForm = new FormEdit(selectedAd, _categories);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAdverts();
                }
            }
            else
            {
                MessageBox.Show("Välj en annons att redigera.");
            }
        }
    }
}
