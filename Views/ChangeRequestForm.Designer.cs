namespace FinancialAssistent.Views
{
    partial class ChangeRequestForm
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
            nameLabel = new Label();
            textBoxRequestName = new TextBox();
            textBoxRequestLastName = new TextBox();
            textBoxRequestEmail = new TextBox();
            textBoxRequestPhone = new TextBox();
            timePickerRequestDateOfBirth = new DateTimePicker();
            lastnameLabel = new Label();
            emailLabel = new Label();
            phoneLabel = new Label();
            dateOfBirthLabel = new Label();
            sendRequestBtn = new Button();
            statusNotificationLabel = new Label();
            rejectBtn = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(47, 52);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(49, 20);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name";
            // 
            // textBoxRequestName
            // 
            textBoxRequestName.Location = new Point(47, 75);
            textBoxRequestName.Name = "textBoxRequestName";
            textBoxRequestName.Size = new Size(125, 27);
            textBoxRequestName.TabIndex = 1;
            // 
            // textBoxRequestLastName
            // 
            textBoxRequestLastName.Location = new Point(228, 75);
            textBoxRequestLastName.Name = "textBoxRequestLastName";
            textBoxRequestLastName.Size = new Size(125, 27);
            textBoxRequestLastName.TabIndex = 2;
            // 
            // textBoxRequestEmail
            // 
            textBoxRequestEmail.Location = new Point(47, 172);
            textBoxRequestEmail.Name = "textBoxRequestEmail";
            textBoxRequestEmail.Size = new Size(125, 27);
            textBoxRequestEmail.TabIndex = 3;
            // 
            // textBoxRequestPhone
            // 
            textBoxRequestPhone.Location = new Point(228, 172);
            textBoxRequestPhone.Name = "textBoxRequestPhone";
            textBoxRequestPhone.Size = new Size(125, 27);
            textBoxRequestPhone.TabIndex = 4;
            // 
            // timePickerRequestDateOfBirth
            // 
            timePickerRequestDateOfBirth.Location = new Point(50, 276);
            timePickerRequestDateOfBirth.Name = "timePickerRequestDateOfBirth";
            timePickerRequestDateOfBirth.Size = new Size(250, 27);
            timePickerRequestDateOfBirth.TabIndex = 5;
            // 
            // lastnameLabel
            // 
            lastnameLabel.AutoSize = true;
            lastnameLabel.Location = new Point(228, 52);
            lastnameLabel.Name = "lastnameLabel";
            lastnameLabel.Size = new Size(72, 20);
            lastnameLabel.TabIndex = 6;
            lastnameLabel.Text = "Lastname";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(46, 149);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 7;
            emailLabel.Text = "Email";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(228, 149);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(105, 20);
            phoneLabel.TabIndex = 8;
            phoneLabel.Text = "Phone number";
            // 
            // dateOfBirthLabel
            // 
            dateOfBirthLabel.AutoSize = true;
            dateOfBirthLabel.Location = new Point(50, 253);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            dateOfBirthLabel.Size = new Size(94, 20);
            dateOfBirthLabel.TabIndex = 9;
            dateOfBirthLabel.Text = "Date of birth";
            // 
            // sendRequestBtn
            // 
            sendRequestBtn.Location = new Point(50, 324);
            sendRequestBtn.Name = "sendRequestBtn";
            sendRequestBtn.Size = new Size(147, 29);
            sendRequestBtn.TabIndex = 10;
            sendRequestBtn.Text = "Send request";
            sendRequestBtn.UseVisualStyleBackColor = true;
            sendRequestBtn.Click += AddChangeRequestBtn_Click;
            // 
            // statusNotificationLabel
            // 
            statusNotificationLabel.AutoSize = true;
            statusNotificationLabel.Location = new Point(42, 22);
            statusNotificationLabel.Name = "statusNotificationLabel";
            statusNotificationLabel.Size = new Size(247, 20);
            statusNotificationLabel.TabIndex = 11;
            statusNotificationLabel.Text = "Your request is in processing status...";
            statusNotificationLabel.Visible = false;
            // 
            // rejectBtn
            // 
            rejectBtn.Location = new Point(203, 324);
            rejectBtn.Name = "rejectBtn";
            rejectBtn.Size = new Size(150, 29);
            rejectBtn.TabIndex = 12;
            rejectBtn.Text = "Reject";
            rejectBtn.UseVisualStyleBackColor = true;
            rejectBtn.Click += RejectBtn_Click;
            // 
            // ChangeRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 414);
            Controls.Add(rejectBtn);
            Controls.Add(statusNotificationLabel);
            Controls.Add(sendRequestBtn);
            Controls.Add(dateOfBirthLabel);
            Controls.Add(phoneLabel);
            Controls.Add(emailLabel);
            Controls.Add(lastnameLabel);
            Controls.Add(timePickerRequestDateOfBirth);
            Controls.Add(textBoxRequestPhone);
            Controls.Add(textBoxRequestEmail);
            Controls.Add(textBoxRequestLastName);
            Controls.Add(textBoxRequestName);
            Controls.Add(nameLabel);
            Name = "ChangeRequestForm";
            Text = "ChangeRequestForm";
            Load += ChangeRequestForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox textBoxRequestName;
        private TextBox textBoxRequestLastName;
        private TextBox textBoxRequestEmail;
        private TextBox textBoxRequestPhone;
        private DateTimePicker timePickerRequestDateOfBirth;
        private Label lastnameLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private Label dateOfBirthLabel;
        private Button sendRequestBtn;
        private Label statusNotificationLabel;
        private Button rejectBtn;
    }
}