namespace FinancialAssistent.Views
{
    partial class AdminRequestsForm
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
            requestLabel = new Label();
            listViewRequests = new ListView();
            processBtn = new Button();
            hintLabel = new Label();
            SuspendLayout();
            // 
            // requestLabel
            // 
            requestLabel.AutoSize = true;
            requestLabel.Location = new Point(35, 37);
            requestLabel.Name = "requestLabel";
            requestLabel.Size = new Size(71, 20);
            requestLabel.TabIndex = 0;
            requestLabel.Text = "Requests:";
            // 
            // listViewRequests
            // 
            listViewRequests.FullRowSelect = true;
            listViewRequests.GridLines = true;
            listViewRequests.LabelEdit = true;
            listViewRequests.Location = new Point(35, 70);
            listViewRequests.Name = "listViewRequests";
            listViewRequests.Size = new Size(1193, 324);
            listViewRequests.TabIndex = 1;
            listViewRequests.UseCompatibleStateImageBehavior = false;
            listViewRequests.View = View.Details;
            listViewRequests.ColumnClick += listViewRequests_ColumnClick;
            // 
            // processBtn
            // 
            processBtn.Location = new Point(35, 410);
            processBtn.Name = "processBtn";
            processBtn.Size = new Size(210, 29);
            processBtn.TabIndex = 2;
            processBtn.Text = "Process the application";
            processBtn.UseVisualStyleBackColor = true;
            processBtn.Click += Processt_Request_Click;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.Location = new Point(811, 37);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(417, 20);
            hintLabel.TabIndex = 3;
            hintLabel.Text = "*You can sort records by status, just click on the status column.";
            // 
            // AdminRequestsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 460);
            Controls.Add(hintLabel);
            Controls.Add(processBtn);
            Controls.Add(listViewRequests);
            Controls.Add(requestLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AdminRequestsForm";
            Text = "Admin Requests";
            Load += AdminRequestsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label requestLabel;
        private ListView listViewRequests;
        private Button processBtn;
        private Label hintLabel;
    }
}