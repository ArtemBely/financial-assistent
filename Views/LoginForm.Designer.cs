namespace FinancialAssistent.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;

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
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(390, 163);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(242, 27);
            emailTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(390, 196);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(242, 27);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(390, 240);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(242, 32);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.Click += LoginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 681);
            Controls.Add(emailTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

    }
}