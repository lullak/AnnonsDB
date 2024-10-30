using AnnonsDatabas.Classes;
using AnnonsDatabas.Entities;
using AnnonsDatabas.Repository;

namespace AnnonsDatabas
{
    public partial class FormEdit : Form
    {
        private Advertisement _advertisement;
        private List<Category> _categories;
        public FormEdit(Advertisement advertisement = null, List<Category> categories = null)
        {
            InitializeComponent();

            _advertisement = advertisement;
            _categories = categories;

            LoadCategories();

            if (_advertisement != null)
            {
                FillFormWithAdvertisementDetails();
                buttonSave.Visible = false;
                buttonEdit.Visible = true;
            }
            else
            {
                buttonEdit.Visible = false;
                buttonSave.Visible = true;
            }
        }

        private void LoadCategories()
        {
            if (_categories != null && _categories.Count > 0)
            {
                comboBoxCategories.DataSource = _categories;
                comboBoxCategories.DisplayMember = "CategoryName";
                comboBoxCategories.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("Inga kategorier är tillgänliga.");
            }
        }

        private void FillFormWithAdvertisementDetails()
        {
            if (_advertisement != null)
            {
                textBoxTitle.Text = _advertisement.Title;
                textBoxDescription.Text = _advertisement.AdDescription;
                numericUpDownPrice.Value = _advertisement.Price;
                comboBoxCategories.SelectedValue = _advertisement.CategoryId;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text.Trim();
            string description = textBoxDescription.Text.Trim();
            decimal price = numericUpDownPrice.Value;
            int categoryId = (int)comboBoxCategories.SelectedValue;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || price <= 0)
            {
                MessageBox.Show("Fyll i alla fält!");
                return;
            }

            _advertisement.Title = title;
            _advertisement.AdDescription = description;
            _advertisement.Price = price;
            _advertisement.CategoryId = categoryId;

            var adRepo = new AdvertisementRepo();

            adRepo.Update(_advertisement);

            MessageBox.Show("Annonsen är nu uppdaterad.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            string title = textBoxTitle.Text.Trim();
            string description = textBoxDescription.Text.Trim();
            decimal price = numericUpDownPrice.Value;
            int categoryId = (int)comboBoxCategories.SelectedValue;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || price <= 0)
            {
                MessageBox.Show("Fyll i alla fält!");
                return;
            }

            var adRepo = new AdvertisementRepo();
            var newAd = new Advertisement(0, title, description, price, categoryId, UserManager.LoggedInUser.Id, DateTime.Now);

            adRepo.Save(newAd);
            MessageBox.Show("Annonsen är nu skapad.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
