namespace AnnonsDatabas
{
    partial class FormEdit
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
            textBoxTitle = new TextBox();
            textBoxDescription = new TextBox();
            numericUpDownPrice = new NumericUpDown();
            comboBoxCategories = new ComboBox();
            buttonSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(66, 43);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(596, 27);
            textBoxTitle.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(66, 99);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(596, 27);
            textBoxDescription.TabIndex = 1;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownPrice.Location = new Point(66, 158);
            numericUpDownPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(596, 27);
            numericUpDownPrice.TabIndex = 2;
            // 
            // comboBoxCategories
            // 
            comboBoxCategories.FormattingEnabled = true;
            comboBoxCategories.Location = new Point(66, 211);
            comboBoxCategories.Name = "comboBoxCategories";
            comboBoxCategories.Size = new Size(596, 28);
            comboBoxCategories.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(568, 274);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Spara";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 20);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 5;
            label1.Text = "Titel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 76);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 6;
            label2.Text = "Beskrivning";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 132);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 7;
            label3.Text = "Pris";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 188);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 8;
            label4.Text = "Kategori";
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(568, 309);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(94, 29);
            buttonEdit.TabIndex = 9;
            buttonEdit.Text = "Redigera";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // FormEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 348);
            Controls.Add(buttonEdit);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(comboBoxCategories);
            Controls.Add(numericUpDownPrice);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxTitle);
            Name = "FormEdit";
            Text = "FormEdit";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTitle;
        private TextBox textBoxDescription;
        private NumericUpDown numericUpDownPrice;
        private ComboBox comboBoxCategories;
        private Button buttonSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonEdit;
    }
}