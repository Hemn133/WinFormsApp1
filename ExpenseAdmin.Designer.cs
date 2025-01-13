namespace WinFormsApp1
{
    partial class ExpenseAdmin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label7 = new Label();
            ExpenseAmount = new TextBox();
            Description = new TextBox();
            button10 = new Button();
            button9 = new Button();
            button11 = new Button();
            dataGridView1 = new DataGridView();
            Label34 = new Label();
            label3 = new Label();
            Label33 = new Label();
            ExpenseDateTextBox = new TextBox();
            ExpenseDatePicker = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(730, 2);
            label7.Name = "label7";
            label7.Size = new Size(157, 69);
            label7.TabIndex = 56;
            label7.Text = "خەرجی";
            // 
            // ExpenseAmount
            // 
            ExpenseAmount.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpenseAmount.Location = new Point(1338, 143);
            ExpenseAmount.Multiline = true;
            ExpenseAmount.Name = "ExpenseAmount";
            ExpenseAmount.Size = new Size(250, 33);
            ExpenseAmount.TabIndex = 55;
            ExpenseAmount.KeyPress += ExpenseAmount_KeyPress;
            // 
            // Description
            // 
            Description.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Description.Location = new Point(937, 143);
            Description.Multiline = true;
            Description.Name = "Description";
            Description.Size = new Size(395, 33);
            Description.TabIndex = 54;
            // 
            // button10
            // 
            button10.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.Teal;
            button10.Location = new Point(1252, 187);
            button10.Name = "button10";
            button10.Size = new Size(336, 35);
            button10.TabIndex = 53;
            button10.Text = "زیادکردن";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.Teal;
            button9.Location = new Point(900, 187);
            button9.Name = "button9";
            button9.Size = new Size(346, 35);
            button9.TabIndex = 52;
            button9.Text = "گۆڕانکاری";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button11
            // 
            button11.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.Red;
            button11.Location = new Point(615, 187);
            button11.Name = "button11";
            button11.Size = new Size(279, 35);
            button11.TabIndex = 51;
            button11.Text = "سڕینەوە";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1600, 785);
            dataGridView1.TabIndex = 50;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // Label34
            // 
            Label34.AutoSize = true;
            Label34.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label34.ForeColor = Color.Teal;
            Label34.Location = new Point(1218, 101);
            Label34.Name = "Label34";
            Label34.Size = new Size(114, 39);
            Label34.TabIndex = 49;
            Label34.Text = "مەبەست";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(1452, 101);
            label3.Name = "label3";
            label3.Size = new Size(136, 39);
            label3.TabIndex = 48;
            label3.Text = "بڕی خەرجی";
            // 
            // Label33
            // 
            Label33.AutoSize = true;
            Label33.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label33.ForeColor = Color.Teal;
            Label33.Location = new Point(854, 101);
            Label33.Name = "Label33";
            Label33.Size = new Size(77, 39);
            Label33.TabIndex = 57;
            Label33.Text = "بەروار";
            // 
            // ExpenseDateTextBox
            // 
            ExpenseDateTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpenseDateTextBox.Location = new Point(311, 65);
            ExpenseDateTextBox.Name = "ExpenseDateTextBox";
            ExpenseDateTextBox.Size = new Size(316, 33);
            ExpenseDateTextBox.TabIndex = 59;
            // 
            // ExpenseDatePicker
            // 
            ExpenseDatePicker.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpenseDatePicker.Format = DateTimePickerFormat.Short;
            ExpenseDatePicker.Location = new Point(615, 143);
            ExpenseDatePicker.Name = "ExpenseDatePicker";
            ExpenseDatePicker.Size = new Size(316, 33);
            ExpenseDatePicker.TabIndex = 60;
            // 
            // ExpenseAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ExpenseDatePicker);
            Controls.Add(ExpenseDateTextBox);
            Controls.Add(Label33);
            Controls.Add(label7);
            Controls.Add(ExpenseAmount);
            Controls.Add(Description);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button11);
            Controls.Add(dataGridView1);
            Controls.Add(Label34);
            Controls.Add(label3);
            Name = "ExpenseAdmin";
            Size = new Size(1616, 1029);
            Load += ExpenseAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox ExpenseAmount;
        private TextBox Description;
        private Button button10;
        private Button button9;
        private Button button11;
        private DataGridView dataGridView1;
        private Label Label34;
        private Label label3;
        private TextBox ExpenseDateTextBox;
        private Label Label33;
        private DateTimePicker ExpenseDatePicker;
    }
}