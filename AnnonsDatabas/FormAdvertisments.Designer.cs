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
            buttonClear = new Button();
            labelLoggedInStatus = new Label();
            buttonCreateAd = new Button();
            buttonDeleteAd = new Button();
            buttonEditAd = new Button();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(12, 44);
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
            comboBoxCategories.SelectedIndexChanged += comboBoxCategories_SelectedIndexChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(417, 43);
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
            buttonLogin.Location = new Point(12, 622);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(161, 29);
            buttonLogin.TabIndex = 8;
            buttonLogin.Text = "Hantera Användare";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // listBoxAds
            // 
            listBoxAds.FormattingEnabled = true;
            listBoxAds.Location = new Point(12, 132);
            listBoxAds.Name = "listBoxAds";
            listBoxAds.Size = new Size(1008, 484);
            listBoxAds.TabIndex = 9;
            listBoxAds.SelectedIndexChanged += listBoxAds_SelectedIndexChanged;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(926, 97);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 29);
            buttonClear.TabIndex = 10;
            buttonClear.Text = "Rensa";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelLoggedInStatus
            // 
            labelLoggedInStatus.AutoSize = true;
            labelLoggedInStatus.Location = new Point(12, 7);
            labelLoggedInStatus.Name = "labelLoggedInStatus";
            labelLoggedInStatus.Size = new Size(460, 20);
            labelLoggedInStatus.TabIndex = 11;
            labelLoggedInStatus.Text = "Ej inloggad, skapa ett konto genom att klicka på hantera användare!";
            // 
            // buttonCreateAd
            // 
            buttonCreateAd.Location = new Point(747, 622);
            buttonCreateAd.Name = "buttonCreateAd";
            buttonCreateAd.Size = new Size(125, 29);
            buttonCreateAd.TabIndex = 12;
            buttonCreateAd.Text = "Ny annons";
            buttonCreateAd.UseVisualStyleBackColor = true;
            buttonCreateAd.Click += buttonCreateAd_Click;
            // 
            // buttonDeleteAd
            // 
            buttonDeleteAd.Location = new Point(559, 621);
            buttonDeleteAd.Name = "buttonDeleteAd";
            buttonDeleteAd.Size = new Size(122, 29);
            buttonDeleteAd.TabIndex = 13;
            buttonDeleteAd.Text = "Radera Annons";
            buttonDeleteAd.UseVisualStyleBackColor = true;
            buttonDeleteAd.Click += buttonDeleteAd_Click;
            // 
            // buttonEditAd
            // 
            buttonEditAd.Location = new Point(889, 622);
            buttonEditAd.Name = "buttonEditAd";
            buttonEditAd.Size = new Size(131, 29);
            buttonEditAd.TabIndex = 14;
            buttonEditAd.Text = "Redigera Annons";
            buttonEditAd.UseVisualStyleBackColor = true;
            buttonEditAd.Click += buttonEditAd_Click;
            // 
            // FormAdvertisments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 663);
            Controls.Add(buttonEditAd);
            Controls.Add(buttonDeleteAd);
            Controls.Add(buttonCreateAd);
            Controls.Add(labelLoggedInStatus);
            Controls.Add(buttonClear);
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
        private Button buttonClear;
        private Label labelLoggedInStatus;
        private Button buttonCreateAd;
        private Button buttonDeleteAd;
        private Button buttonEditAd;
    }
}