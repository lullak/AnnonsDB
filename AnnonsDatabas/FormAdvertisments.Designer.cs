namespace AnnonsDatabas
{
    partial class FormAdvertisments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxSearch = new TextBox();
            comboBoxCategories = new ComboBox();
            buttonSearch = new Button();
            buttonDateSort = new Button();
            buttonPriceSort = new Button();
            labelSort = new Label();
            label1 = new Label();
            buttonLogin = new Button();
            listBoxAds = new ListBox();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(12, 30);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(387, 27);
            textBoxSearch.TabIndex = 0;
            // 
            // comboBoxCategories
            // 
            comboBoxCategories.FormattingEnabled = true;
            comboBoxCategories.Location = new Point(235, 97);
            comboBoxCategories.Name = "comboBoxCategories";
            comboBoxCategories.Size = new Size(168, 28);
            comboBoxCategories.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(405, 30);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Sök";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonDateSort
            // 
            buttonDateSort.Location = new Point(119, 97);
            buttonDateSort.Name = "buttonDateSort";
            buttonDateSort.Size = new Size(94, 29);
            buttonDateSort.TabIndex = 4;
            buttonDateSort.Text = "Datum";
            buttonDateSort.UseVisualStyleBackColor = true;
            buttonDateSort.Click += buttonDateSort_Click;
            // 
            // buttonPriceSort
            // 
            buttonPriceSort.Location = new Point(12, 97);
            buttonPriceSort.Name = "buttonPriceSort";
            buttonPriceSort.Size = new Size(94, 29);
            buttonPriceSort.TabIndex = 5;
            buttonPriceSort.Text = "Pris";
            buttonPriceSort.UseVisualStyleBackColor = true;
            buttonPriceSort.Click += buttonPriceSort_Click;
            // 
            // labelSort
            // 
            labelSort.AutoSize = true;
            labelSort.Location = new Point(12, 74);
            labelSort.Name = "labelSort";
            labelSort.Size = new Size(57, 20);
            labelSort.TabIndex = 6;
            labelSort.Text = "Sortera";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 74);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 7;
            label1.Text = "Kategori";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(859, 622);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(161, 29);
            buttonLogin.TabIndex = 8;
            buttonLogin.Text = "Hantera Användare";
            buttonLogin.UseVisualStyleBackColor = true;
            // 
            // listBoxAds
            // 
            listBoxAds.FormattingEnabled = true;
            listBoxAds.Location = new Point(12, 132);
            listBoxAds.Name = "listBoxAds";
            listBoxAds.Size = new Size(754, 464);
            listBoxAds.TabIndex = 9;
            // 
            // FormAdvertisments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 663);
            Controls.Add(listBoxAds);
            Controls.Add(buttonLogin);
            Controls.Add(label1);
            Controls.Add(labelSort);
            Controls.Add(buttonPriceSort);
            Controls.Add(buttonDateSort);
            Controls.Add(buttonSearch);
            Controls.Add(comboBoxCategories);
            Controls.Add(textBoxSearch);
            Name = "FormAdvertisments";
            Text = "Annonser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSearch;
        private ComboBox comboBoxCategories;
        private Button buttonSearch;
        private Button buttonDateSort;
        private Button buttonPriceSort;
        private Label labelSort;
        private Label label1;
        private Button buttonLogin;
        private ListBox listBoxAds;
    }
}