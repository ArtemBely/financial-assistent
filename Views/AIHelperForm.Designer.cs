namespace FinancialAssistent.Views
{
    partial class AIHelperForm
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
            categoryCombobox = new ComboBox();
            acceptLimitBtn = new Button();
            limitTextBox = new TextBox();
            recommentationLbl = new Label();
            catagoryLbl = new Label();
            limitLbl = new Label();
            showAdvicesBtn = new Button();
            SuspendLayout();
            // 
            // categoryCombobox
            // 
            categoryCombobox.FormattingEnabled = true;
            categoryCombobox.Location = new Point(206, 86);
            categoryCombobox.Name = "categoryCombobox";
            categoryCombobox.Size = new Size(151, 28);
            categoryCombobox.TabIndex = 0;
            // 
            // acceptLimitBtn
            // 
            acceptLimitBtn.Location = new Point(61, 198);
            acceptLimitBtn.Name = "acceptLimitBtn";
            acceptLimitBtn.Size = new Size(187, 29);
            acceptLimitBtn.TabIndex = 1;
            acceptLimitBtn.Text = "Accept limit";
            acceptLimitBtn.UseVisualStyleBackColor = true;
            acceptLimitBtn.Click += Accept_Budget;
            // 
            // limitTextBox
            // 
            limitTextBox.Location = new Point(206, 134);
            limitTextBox.Name = "limitTextBox";
            limitTextBox.Size = new Size(151, 27);
            limitTextBox.TabIndex = 2;
            // 
            // recommentationLbl
            // 
            recommentationLbl.AutoSize = true;
            recommentationLbl.Location = new Point(61, 44);
            recommentationLbl.Name = "recommentationLbl";
            recommentationLbl.Size = new Size(427, 20);
            recommentationLbl.TabIndex = 3;
            recommentationLbl.Text = "Define month's limits by category. Recommendation character*";
            // 
            // catagoryLbl
            // 
            catagoryLbl.AutoSize = true;
            catagoryLbl.Location = new Point(61, 86);
            catagoryLbl.Name = "catagoryLbl";
            catagoryLbl.Size = new Size(120, 20);
            catagoryLbl.TabIndex = 5;
            catagoryLbl.Text = "Choose category";
            // 
            // limitLbl
            // 
            limitLbl.AutoSize = true;
            limitLbl.Location = new Point(61, 134);
            limitLbl.Name = "limitLbl";
            limitLbl.Size = new Size(87, 20);
            limitLbl.TabIndex = 6;
            limitLbl.Text = "Define limit";
            // 
            // showAdvicesBtn
            // 
            showAdvicesBtn.BackColor = SystemColors.ActiveBorder;
            showAdvicesBtn.Location = new Point(61, 253);
            showAdvicesBtn.Name = "showAdvicesBtn";
            showAdvicesBtn.Size = new Size(187, 29);
            showAdvicesBtn.TabIndex = 7;
            showAdvicesBtn.Text = "Show AI advices";
            showAdvicesBtn.UseVisualStyleBackColor = false;
            showAdvicesBtn.Click += BtnUpdateBudgetAdvices_Click;
            // 
            // AIHelperForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showAdvicesBtn);
            Controls.Add(limitLbl);
            Controls.Add(catagoryLbl);
            Controls.Add(recommentationLbl);
            Controls.Add(limitTextBox);
            Controls.Add(acceptLimitBtn);
            Controls.Add(categoryCombobox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AIHelperForm";
            Text = "AI Helper";
            Load += AIHelperForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox categoryCombobox;
        private Button acceptLimitBtn;
        private TextBox limitTextBox;
        private Label recommentationLbl;
        private Label catagoryLbl;
        private Label limitLbl;
        private Button showAdvicesBtn;
    }
}