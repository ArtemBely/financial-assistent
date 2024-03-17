namespace FinancialAssistent.Views
{
    partial class TransactionForm
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
            addTransactionLabel = new Label();
            amountBtn = new TextBox();
            amountLabel = new Label();
            addDateLabel = new Label();
            dateTimePicker1 = new DateTimePicker();
            addTransactionBtn = new Button();
            categoryTxtLabel = new Label();
            categoryCombobox = new ComboBox();
            addCategoryLabel = new Label();
            newCategoryTextbox = new TextBox();
            categoryLabel = new Label();
            addCategoryBtn = new Button();
            allTransactionsListbox = new Label();
            backToAccountBtn = new Button();
            allCategoryListbox = new ListBox();
            categoryListboxLabel = new Label();
            deleteBtn = new Button();
            editBtn = new Button();
            allTransactionListView = new ListView();
            allCategoryListView = new ListView();
            editCategoryBtn = new Button();
            deleteCategoryBtn = new Button();
            SuspendLayout();
            // 
            // addTransactionLabel
            // 
            addTransactionLabel.AutoSize = true;
            addTransactionLabel.Location = new Point(80, 56);
            addTransactionLabel.Name = "addTransactionLabel";
            addTransactionLabel.Size = new Size(227, 20);
            addTransactionLabel.TabIndex = 0;
            addTransactionLabel.Text = "Please, add incoming transaction";
            // 
            // amountBtn
            // 
            amountBtn.Location = new Point(80, 151);
            amountBtn.Name = "amountBtn";
            amountBtn.Size = new Size(151, 27);
            amountBtn.TabIndex = 1;
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(80, 119);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(62, 20);
            amountLabel.TabIndex = 2;
            amountLabel.Text = "Amount";
            // 
            // addDateLabel
            // 
            addDateLabel.AutoSize = true;
            addDateLabel.Location = new Point(311, 119);
            addDateLabel.Name = "addDateLabel";
            addDateLabel.Size = new Size(71, 20);
            addDateLabel.TabIndex = 3;
            addDateLabel.Text = "Add date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(311, 149);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(220, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // addTransactionBtn
            // 
            addTransactionBtn.Location = new Point(311, 250);
            addTransactionBtn.Name = "addTransactionBtn";
            addTransactionBtn.Size = new Size(151, 29);
            addTransactionBtn.TabIndex = 5;
            addTransactionBtn.Text = "Add";
            addTransactionBtn.UseVisualStyleBackColor = true;
            addTransactionBtn.Click += AddTransactionBtn_Click;
            // 
            // categoryTxtLabel
            // 
            categoryTxtLabel.AutoSize = true;
            categoryTxtLabel.Location = new Point(80, 218);
            categoryTxtLabel.Name = "categoryTxtLabel";
            categoryTxtLabel.Size = new Size(99, 20);
            categoryTxtLabel.TabIndex = 6;
            categoryTxtLabel.Text = "Add category";
            // 
            // categoryCombobox
            // 
            categoryCombobox.FormattingEnabled = true;
            categoryCombobox.Location = new Point(80, 250);
            categoryCombobox.Name = "categoryCombobox";
            categoryCombobox.Size = new Size(151, 28);
            categoryCombobox.TabIndex = 7;
            // 
            // addCategoryLabel
            // 
            addCategoryLabel.AutoSize = true;
            addCategoryLabel.Location = new Point(735, 56);
            addCategoryLabel.Name = "addCategoryLabel";
            addCategoryLabel.Size = new Size(177, 20);
            addCategoryLabel.TabIndex = 8;
            addCategoryLabel.Text = "Please, add new category";
            // 
            // newCategoryTextbox
            // 
            newCategoryTextbox.Location = new Point(735, 149);
            newCategoryTextbox.Name = "newCategoryTextbox";
            newCategoryTextbox.Size = new Size(177, 27);
            newCategoryTextbox.TabIndex = 9;
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(735, 119);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(69, 20);
            categoryLabel.TabIndex = 10;
            categoryLabel.Text = "Category";
            // 
            // addCategoryBtn
            // 
            addCategoryBtn.Location = new Point(735, 250);
            addCategoryBtn.Name = "addCategoryBtn";
            addCategoryBtn.Size = new Size(151, 29);
            addCategoryBtn.TabIndex = 11;
            addCategoryBtn.Text = "Add";
            addCategoryBtn.UseVisualStyleBackColor = true;
            addCategoryBtn.Click += Add_New_Category;
            // 
            // allTransactionsListbox
            // 
            allTransactionsListbox.AutoSize = true;
            allTransactionsListbox.Location = new Point(80, 339);
            allTransactionsListbox.Name = "allTransactionsListbox";
            allTransactionsListbox.Size = new Size(110, 20);
            allTransactionsListbox.TabIndex = 13;
            allTransactionsListbox.Text = "All transactions";
            // 
            // backToAccountBtn
            // 
            backToAccountBtn.Location = new Point(80, 598);
            backToAccountBtn.Name = "backToAccountBtn";
            backToAccountBtn.Size = new Size(206, 29);
            backToAccountBtn.TabIndex = 14;
            backToAccountBtn.Text = "Back to account";
            backToAccountBtn.UseVisualStyleBackColor = true;
            backToAccountBtn.Click += Back_To_Profile;
            // 
            // allCategoryListbox
            // 
            allCategoryListbox.ItemHeight = 20;
            allCategoryListbox.Location = new Point(735, 373);
            allCategoryListbox.Name = "allCategoryListbox";
            allCategoryListbox.Size = new Size(177, 204);
            allCategoryListbox.TabIndex = 19;
            // 
            // categoryListboxLabel
            // 
            categoryListboxLabel.AutoSize = true;
            categoryListboxLabel.Location = new Point(735, 339);
            categoryListboxLabel.Name = "categoryListboxLabel";
            categoryListboxLabel.Size = new Size(100, 20);
            categoryListboxLabel.TabIndex = 16;
            categoryListboxLabel.Text = "All categories";
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(537, 408);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(94, 29);
            deleteBtn.TabIndex = 17;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += Delete_Transaction;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(537, 373);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(94, 29);
            editBtn.TabIndex = 18;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += Edit_Transaction;
            // 
            // allTransactionListView
            // 
            allTransactionListView.FullRowSelect = true;
            allTransactionListView.GridLines = true;
            allTransactionListView.Location = new Point(80, 373);
            allTransactionListView.Name = "allTransactionListView";
            allTransactionListView.Size = new Size(451, 204);
            allTransactionListView.TabIndex = 19;
            allTransactionListView.UseCompatibleStateImageBehavior = false;
            allTransactionListView.View = View.Details;
            // 
            // allCategoryListView
            // 
            allCategoryListView.FullRowSelect = true;
            allCategoryListView.GridLines = true;
            allCategoryListView.LabelEdit = true;
            allCategoryListView.Location = new Point(735, 373);
            allCategoryListView.Name = "allCategoryListView";
            allCategoryListView.Size = new Size(176, 204);
            allCategoryListView.TabIndex = 15;
            allCategoryListView.UseCompatibleStateImageBehavior = false;
            allCategoryListView.View = View.Details;
            // 
            // editCategoryBtn
            // 
            editCategoryBtn.Location = new Point(635, 513);
            editCategoryBtn.Name = "editCategoryBtn";
            editCategoryBtn.Size = new Size(94, 29);
            editCategoryBtn.TabIndex = 20;
            editCategoryBtn.Text = "Edit";
            editCategoryBtn.UseVisualStyleBackColor = true;
            editCategoryBtn.Click += Edit_Category;
            // 
            // deleteCategoryBtn
            // 
            deleteCategoryBtn.Location = new Point(635, 548);
            deleteCategoryBtn.Name = "deleteCategoryBtn";
            deleteCategoryBtn.Size = new Size(94, 29);
            deleteCategoryBtn.TabIndex = 21;
            deleteCategoryBtn.Text = "Delete";
            deleteCategoryBtn.UseVisualStyleBackColor = true;
            deleteCategoryBtn.Click += Delete_Category;
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 681);
            Controls.Add(deleteCategoryBtn);
            Controls.Add(editCategoryBtn);
            Controls.Add(editBtn);
            Controls.Add(deleteBtn);
            Controls.Add(categoryListboxLabel);
            Controls.Add(backToAccountBtn);
            Controls.Add(allTransactionsListbox);
            Controls.Add(allTransactionListView);
            Controls.Add(allCategoryListView);
            Controls.Add(addCategoryBtn);
            Controls.Add(categoryLabel);
            Controls.Add(newCategoryTextbox);
            Controls.Add(addCategoryLabel);
            Controls.Add(categoryCombobox);
            Controls.Add(categoryTxtLabel);
            Controls.Add(addTransactionBtn);
            Controls.Add(dateTimePicker1);
            Controls.Add(addDateLabel);
            Controls.Add(amountLabel);
            Controls.Add(amountBtn);
            Controls.Add(addTransactionLabel);
            Name = "TransactionForm";
            Text = "Transactions";
            Load += TransactionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label addTransactionLabel;
        private TextBox amountBtn;
        private Label amountLabel;
        private Label addDateLabel;
        private DateTimePicker dateTimePicker1;
        private Button addTransactionBtn;
        private Label categoryTxtLabel;
        private ComboBox categoryCombobox;
        private Label addCategoryLabel;
        private TextBox newCategoryTextbox;
        private Label categoryLabel;
        private Button addCategoryBtn;

        #endregion

        private Label allTransactionsListbox;
        private Button backToAccountBtn;
        private ListBox allCategoryListbox;
        private Label categoryListboxLabel;
        private Button deleteBtn;
        private Button editBtn;
        private ListView allTransactionListView;
        private ListView allCategoryListView;
        private Button editCategoryBtn;
        private Button deleteCategoryBtn;
    }
}