using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialAssistent.Views
{
    partial class UserProfileForm
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
            labelFirstName = new Label();
            panelHeader = new Panel();
            labelEmail = new Label();
            labelYear = new Label();
            chooseMonthBtn = new Button();
            newTransaction = new Button();
            aiHelper = new Button();
            requestHistoryBtn = new Button();
            monthComboBox = new ComboBox();
            chartExpenses = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();

            ((System.ComponentModel.ISupportInitialize)(chartExpenses)).BeginInit();
            phoneNumberLabel = new Label();
            phoneNumber = new Label();
            dateOfBirthLabel = new Label();
            dateOfBirthContent = new Label();
            editProfileBtn = new Button();
            SuspendLayout();
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFirstName.ForeColor = Color.Black;
            labelFirstName.Location = new Point(30, 92);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(0, 19);
            labelFirstName.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.LightGray;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(990, 60);
            panelHeader.TabIndex = 0;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.ForeColor = Color.Black;
            labelEmail.Location = new Point(30, 132);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(0, 19);
            labelEmail.TabIndex = 2;
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelYear.ForeColor = Color.Black;
            labelYear.Location = new Point(30, 330);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(195, 19);
            labelYear.TabIndex = 2;
            labelYear.Text = "Information for year 2024";
            // 
            // chooseMonthBtn
            // 
            chooseMonthBtn.Location = new Point(30, 413);
            chooseMonthBtn.Name = "chooseMonthBtn";
            chooseMonthBtn.Size = new Size(152, 29);
            chooseMonthBtn.TabIndex = 4;
            chooseMonthBtn.Text = "Choose";
            chooseMonthBtn.UseVisualStyleBackColor = true;
            chooseMonthBtn.Click += ButtonChoose_Click;
            // 
            // newTransaction
            // 
            newTransaction.Location = new Point(30, 480);
            newTransaction.Name = "newTransaction";
            newTransaction.Size = new Size(152, 29);
            newTransaction.TabIndex = 4;
            newTransaction.Text = "Add Transaction";
            newTransaction.UseVisualStyleBackColor = true;
            newTransaction.Click += TransactionChoose_Click;
            // 
            // aiHelper
            // 
            aiHelper.Location = new Point(30, 524);
            aiHelper.Name = "aiHelper";
            aiHelper.Size = new Size(152, 29);
            aiHelper.TabIndex = 4;
            aiHelper.Text = "AI Helper";
            aiHelper.UseVisualStyleBackColor = true;
            aiHelper.Click += ButtonChoose_Click;
            //
            // requestHistory
            //
            requestHistoryBtn.Location = new Point(30, 590);
            requestHistoryBtn.Name = "requestHistory";
            requestHistoryBtn.Size = new Size(152, 29);
            requestHistoryBtn.TabIndex = 4;
            requestHistoryBtn.Text = "Requests History";
            requestHistoryBtn.UseVisualStyleBackColor = true;
            requestHistoryBtn.Click += RequestHistory_Click;
            // 
            // chartExpenses
            // 
            chartArea1.Name = "ChartArea1";
            chartExpenses.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartExpenses.Legends.Add(legend1);
            chartExpenses.Location = new Point(370, 75);
            chartExpenses.Name = "chartExpenses";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartExpenses.Series.Add(series1);
            chartExpenses.Size = new Size(600, 600);
            chartExpenses.TabIndex = 3;
            chartExpenses.ChartAreas[0].BackColor = Color.Transparent;
            chartExpenses.BackColor = Color.Transparent;
            chartExpenses.Text = "chart1";
            // 
            // monthComboBox
            // 
            monthComboBox.FormattingEnabled = true;
            monthComboBox.Location = new Point(30, 369);
            monthComboBox.Name = "monthComboBox";
            monthComboBox.Size = new Size(151, 28);
            monthComboBox.TabIndex = 3;
            monthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            monthComboBox.Items.Insert(0, "All period");
            monthComboBox.SelectedIndex = 0;
            monthComboBox.Items.AddRange(new object[] {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"});
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumberLabel.ForeColor = Color.Black;
            phoneNumberLabel.Location = new Point(30, 196);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(0, 20);
            phoneNumberLabel.TabIndex = 5;
            // 
            // phoneNumber
            // 
            phoneNumber.AutoSize = true;
            phoneNumber.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumber.ForeColor = Color.Black;
            phoneNumber.Location = new Point(30, 176);
            phoneNumber.Text = "Tel:";
            phoneNumber.Name = "phoneNumber";
            phoneNumber.Size = new Size(0, 20);
            phoneNumber.TabIndex = 5;
            // 
            // dateOfBirthLabel
            // 
            dateOfBirthLabel.AutoSize = true;
            dateOfBirthLabel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateOfBirthLabel.ForeColor = Color.Black;
            dateOfBirthLabel.Location = new Point(30, 236);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            dateOfBirthLabel.Size = new Size(94, 20);
            dateOfBirthLabel.TabIndex = 6;
            dateOfBirthLabel.Text = "Date of birth:";
            // 
            // dateOfBirthContent
            // 
            dateOfBirthContent.AutoSize = true;
            dateOfBirthContent.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateOfBirthContent.ForeColor = Color.Black;
            dateOfBirthContent.Location = new Point(30, 256);
            dateOfBirthContent.Name = "dateOfBirthContent";
            dateOfBirthContent.Size = new Size(0, 20);
            dateOfBirthContent.TabIndex = 7;
            // 
            // editProfileBtn
            // 
            editProfileBtn.Location = new Point(322, 161);
            editProfileBtn.Name = "editProfileBtn";
            editProfileBtn.Size = new Size(94, 29);
            editProfileBtn.TabIndex = 8;
            editProfileBtn.Text = "Edit profile";
            editProfileBtn.UseVisualStyleBackColor = true;
            editProfileBtn.Click += EditProfileBtn_Click;
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 681);
            Controls.Add(editProfileBtn);
            Controls.Add(dateOfBirthContent);
            Controls.Add(dateOfBirthLabel);
            Controls.Add(phoneNumber);
            Controls.Add(phoneNumberLabel);
            Controls.Add(panelHeader);
            Controls.Add(labelEmail);
            Controls.Add(labelFirstName);
            Controls.Add(chartExpenses);
            Controls.Add(labelYear);
            Controls.Add(monthComboBox);
            Controls.Add(chooseMonthBtn);
            Controls.Add(newTransaction);
            Controls.Add(aiHelper);
            Controls.Add(requestHistoryBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserProfileForm";
            Text = "User Profile";
            Activated += UserProfileForm_Load;
            Load += UserProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)(chartExpenses)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFirstName;
        private Panel panelHeader;
        private ComboBox monthComboBox;
        private Button chooseMonthBtn;
        private Button requestHistoryBtn;
        private Button newTransaction;
        private Button aiHelper;
        private Label labelEmail;
        private Label labelYear;
        private Chart chartExpenses;
        private Label phoneNumberLabel;
        private Label phoneNumber;
        private Label dateOfBirthLabel;
        private Label dateOfBirthContent;
        private Button editProfileBtn;
    }
}