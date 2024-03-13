namespace FinancialAssistent.Views
{
    partial class EditTransactionForm
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
            dateTimePicker2 = new DateTimePicker();
            amountTextbox = new TextBox();
            editDialogLabel = new Label();
            categoryCombobox = new ComboBox();
            saveBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(88, 94);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 0;
            // 
            // amountTextbox
            // 
            amountTextbox.Location = new Point(88, 145);
            amountTextbox.Name = "amountTextbox";
            amountTextbox.Size = new Size(125, 27);
            amountTextbox.TabIndex = 1;
            // 
            // editDialogLabel
            // 
            editDialogLabel.AutoSize = true;
            editDialogLabel.Location = new Point(90, 49);
            editDialogLabel.Name = "editDialogLabel";
            editDialogLabel.Size = new Size(208, 20);
            editDialogLabel.TabIndex = 3;
            editDialogLabel.Text = "Please, edit transaction record";
            // 
            // categoryCombobox
            // 
            categoryCombobox.FormattingEnabled = true;
            categoryCombobox.Location = new Point(88, 195);
            categoryCombobox.Name = "categoryCombobox";
            categoryCombobox.Size = new Size(151, 28);
            categoryCombobox.TabIndex = 4;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(88, 255);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 29);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(204, 255);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // EditTransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 358);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(categoryCombobox);
            Controls.Add(editDialogLabel);
            Controls.Add(amountTextbox);
            Controls.Add(dateTimePicker2);
            Name = "EditTransactionForm";
            Text = "Edit Transaction";
            Load += EditTransactionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker2;
        private TextBox amountTextbox;
        private Label editDialogLabel;
        private ComboBox categoryCombobox;
        private Button saveBtn;
        private Button cancelBtn;
    }
}