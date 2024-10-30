using AnnonsDatabas.Repository;

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

        private void LoadCategories()
        {
            CategoryRepo repo = new CategoryRepo();
            var categories = repo.GetList();

            comboBoxCategories.DisplayMember = "CategoryName";
            comboBoxCategories.ValueMember = "CategoryID";
            comboBoxCategories.DataSource = categories;
        }
        private void LoadAdverts()
        {
            AdvertisementRepo repo = new AdvertisementRepo();
            var adverts = repo.GetList();

            listBoxAds.DisplayMember = "ToString";
            listBoxAds.ValueMember = "Id";
            listBoxAds.DataSource = adverts;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonPriceSort_Click(object sender, EventArgs e)
        {

        }

        private void buttonDateSort_Click(object sender, EventArgs e)
        {

        }
    }
}
