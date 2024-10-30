using AnnonsDatabas.Classes;
using AnnonsDatabas.Entities;
using AnnonsDatabas.Repository;

namespace AnnonsDatabas
{
    public partial class FormEdit : Form
    {
        private Advertisement _advertisement; // Field to hold the advertisement being edited
        private List<Category> _categories; // Field to hold the list of categories

        // Modify the constructor to accept categories
        public FormEdit(Advertisement advertisement = null, List<Category> categories = null)
        {
            InitializeComponent();

            _advertisement = advertisement; // Store the advertisement if it is passed, which indicates we are editing
            _categories = categories; // Store the categories for loading into the ComboBox

            // Load categories into the combo box
            LoadCategories();

            // If an advertisement is provided, fill in the details for editing
            if (_advertisement != null)
            {
                FillFormWithAdvertisementDetails();
                buttonSave.Visible = false; // Hide Save button if editing
                buttonEdit.Visible = true; // Show Edit button
            }
            else
            {
                buttonEdit.Visible = false; // Hide Edit button if creating new
                buttonSave.Visible = true; // Show Save button
            }
        }

        private void LoadCategories()
        {
            if (_categories != null && _categories.Count > 0)
            {
                comboBoxCategories.DataSource = _categories;
                comboBoxCategories.DisplayMember = "CategoryName"; // Assuming category has a Name property
                comboBoxCategories.ValueMember = "Id"; // Assuming category has an Id property
            }
            else
            {
                MessageBox.Show("No categories available."); // Debugging message if categories are null
            }
        }

        private void FillFormWithAdvertisementDetails()
        {
            if (_advertisement != null)
            {
                textBoxTitle.Text = _advertisement.Title;
                textBoxDescription.Text = _advertisement.AdDescription;
                numericUpDownPrice.Value = _advertisement.Price;
                comboBoxCategories.SelectedValue = _advertisement.CategoryId; // Set selected category
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Gather input values from the form
            string title = textBoxTitle.Text.Trim();
            string description = textBoxDescription.Text.Trim();
            decimal price = numericUpDownPrice.Value;
            int categoryId = (int)comboBoxCategories.SelectedValue; // Assuming category selection is valid

            // Validate inputs
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || price <= 0)
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            // Update the advertisement object with new values
            _advertisement.Title = title;
            _advertisement.AdDescription = description;
            _advertisement.Price = price;
            _advertisement.CategoryId = categoryId;

            var adRepo = new AdvertisementRepo();
            // Save changes to the database
            adRepo.Update(_advertisement);

            MessageBox.Show("Advertisement updated successfully.");
            this.DialogResult = DialogResult.OK; // Return OK result
            this.Close(); // Close the form
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Gather input values from the form
            string title = textBoxTitle.Text.Trim();
            string description = textBoxDescription.Text.Trim();
            decimal price = numericUpDownPrice.Value;
            int categoryId = (int)comboBoxCategories.SelectedValue; // Assuming category selection is valid

            // Validate inputs
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || price <= 0)
            {
                MessageBox.Show("Fyll i alla fält!");
                return;
            }

            var adRepo = new AdvertisementRepo();
            // Create a new advertisement object
            var newAd = new Advertisement(0, title, description, price, categoryId, UserManager.LoggedInUser.Id, DateTime.Now);

            // Save to the database
            adRepo.Save(newAd);
            MessageBox.Show("Annonsen är nu skapad.");

            this.DialogResult = DialogResult.OK; // Return OK result
            this.Close(); // Close the form
        }
    }
}
