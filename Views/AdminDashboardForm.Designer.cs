namespace FinancialAssistent.Views
{
    partial class AdminDashboardForm
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
            requestBtn = new Button();
            usersLabel = new Label();
            usersListview = new ListView();
            SuspendLayout();
            // 
            // requestBtn
            // 
            requestBtn.Location = new Point(25, 404);
            requestBtn.Name = "requestBtn";
            requestBtn.Size = new Size(145, 29);
            requestBtn.TabIndex = 0;
            requestBtn.Text = "Show Requests";
            requestBtn.UseVisualStyleBackColor = true;
            requestBtn.Click += Show_Requests;
            // 
            // usersLabel
            // 
            usersLabel.AutoSize = true;
            usersLabel.Location = new Point(25, 36);
            usersLabel.Name = "usersLabel";
            usersLabel.Size = new Size(81, 20);
            usersLabel.TabIndex = 1;
            usersLabel.Text = "Customers:";
            // 
            // usersListview
            // 
            usersListview.FullRowSelect = true;
            usersListview.GridLines = true;
            usersListview.LabelEdit = true;
            usersListview.Location = new Point(25, 77);
            usersListview.Name = "usersListview";
            usersListview.Size = new Size(676, 307);
            usersListview.TabIndex = 15;
            usersListview.UseCompatibleStateImageBehavior = false;
            usersListview.View = View.Details;
            usersListview.SelectedIndexChanged += usersListview_SelectedIndexChanged;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 458);
            Controls.Add(usersListview);
            Controls.Add(usersLabel);
            Controls.Add(requestBtn);
            Name = "AdminDashboardForm";
            Text = "Admin Dashboard";
            Load += AdminDashboardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button requestBtn;
        private Label usersLabel;
        private ListView usersListview;
    }
}