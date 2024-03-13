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
            monthComboBox = new ComboBox();

            chartExpenses = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();

            ((System.ComponentModel.ISupportInitialize)(chartExpenses)).BeginInit();

            SuspendLayout();

            panelHeader.BackColor = Color.LightGray;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Size = new Size(ClientSize.Width, 60);
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(30, 92);
            labelFirstName.Font = new Font("Arial", 10, FontStyle.Regular);
            labelFirstName.ForeColor = Color.Black;
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(0, 20);
            labelFirstName.TabIndex = 0;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(30, 132);
            labelEmail.Font = new Font("Arial", 10, FontStyle.Regular);
            labelEmail.ForeColor = Color.Black;
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(0, 20);
            labelEmail.TabIndex = 2;
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(30, 330);
            labelYear.Font = new Font("Arial", 10, FontStyle.Regular);
            labelYear.ForeColor = Color.Black;
            labelYear.Name = "labelYear";
            labelYear.Text = "Information for year 2024";
            labelYear.Size = new Size(0, 20);
            labelYear.TabIndex = 2;
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
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 681);
            Controls.Add(panelHeader);
            Controls.Add(labelEmail);
            Controls.Add(labelFirstName);
            Controls.Add(chartExpenses);
            Controls.Add(labelYear);
            Controls.Add(monthComboBox);
            Controls.Add(chooseMonthBtn);
            Controls.Add(newTransaction);
            Controls.Add(aiHelper);

            Name = "UserProfileForm";
            Text = "User Profile";

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Load += UserProfileForm_Load;
            Activated += UserProfileForm_Load;

            ((System.ComponentModel.ISupportInitialize)(chartExpenses)).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFirstName;
        private Panel panelHeader;
        private ComboBox monthComboBox;
        private Button chooseMonthBtn;
        private Button newTransaction;
        private Button aiHelper;
        private Label labelEmail;
        private Label labelYear;
        private Chart chartExpenses;
    }
}