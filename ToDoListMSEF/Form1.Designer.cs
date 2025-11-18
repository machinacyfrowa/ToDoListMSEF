namespace ToDoListMSEF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ToDoNameTextBox = new TextBox();
            label1 = new Label();
            ToDoDateTimePicker = new DateTimePicker();
            AddToDoButton = new Button();
            label2 = new Label();
            ToDoDataGridView = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)ToDoDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ToDoNameTextBox
            // 
            ToDoNameTextBox.Location = new Point(29, 47);
            ToDoNameTextBox.Name = "ToDoNameTextBox";
            ToDoNameTextBox.Size = new Size(334, 23);
            ToDoNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 29);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 1;
            label1.Text = "Zadanie od wykonania:";
            // 
            // ToDoDateTimePicker
            // 
            ToDoDateTimePicker.Format = DateTimePickerFormat.Short;
            ToDoDateTimePicker.Location = new Point(369, 47);
            ToDoDateTimePicker.Name = "ToDoDateTimePicker";
            ToDoDateTimePicker.Size = new Size(200, 23);
            ToDoDateTimePicker.TabIndex = 2;
            // 
            // AddToDoButton
            // 
            AddToDoButton.Location = new Point(575, 46);
            AddToDoButton.Name = "AddToDoButton";
            AddToDoButton.Size = new Size(75, 23);
            AddToDoButton.TabIndex = 3;
            AddToDoButton.Text = "Dodaj";
            AddToDoButton.UseVisualStyleBackColor = true;
            AddToDoButton.Click += AddToDoButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(369, 29);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 4;
            label2.Text = "Termin wykonania:";
            // 
            // ToDoDataGridView
            // 
            ToDoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ToDoDataGridView.Location = new Point(29, 95);
            ToDoDataGridView.Name = "ToDoDataGridView";
            ToDoDataGridView.Size = new Size(621, 313);
            ToDoDataGridView.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ToDoDataGridView);
            Controls.Add(label2);
            Controls.Add(AddToDoButton);
            Controls.Add(ToDoDateTimePicker);
            Controls.Add(label1);
            Controls.Add(ToDoNameTextBox);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            ((System.ComponentModel.ISupportInitialize)ToDoDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ToDoNameTextBox;
        private Label label1;
        private DateTimePicker ToDoDateTimePicker;
        private Button AddToDoButton;
        private Label label2;
        private DataGridView ToDoDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
