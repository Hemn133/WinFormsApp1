namespace WinFormsApp1
{
    partial class ReturnAdmin
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            dataGridView2 = new DataGridView();
            ExpenseAmount = new TextBox();
            label3 = new Label();
            button2 = new Button();
            ProductSelection = new ComboBox();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            addtolist = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(654, 0);
            label7.Name = "label7";
            label7.Size = new Size(309, 69);
            label7.TabIndex = 36;
            label7.Text = "گەڕانەوەی کاڵا";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1610, 227);
            dataGridView1.TabIndex = 51;
            // 
            // button1
            // 
            button1.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(3, 97);
            button1.Name = "button1";
            button1.Size = new Size(292, 33);
            button1.TabIndex = 54;
            button1.Text = "سڕینەوە";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(3, 444);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(1610, 273);
            dataGridView2.TabIndex = 55;
            // 
            // ExpenseAmount
            // 
            ExpenseAmount.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpenseAmount.Location = new Point(1319, 94);
            ExpenseAmount.Multiline = true;
            ExpenseAmount.Name = "ExpenseAmount";
            ExpenseAmount.Size = new Size(118, 33);
            ExpenseAmount.TabIndex = 57;
            ExpenseAmount.KeyPress += ExpenseAmount_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(1443, 91);
            label3.Name = "label3";
            label3.Size = new Size(168, 39);
            label3.TabIndex = 56;
            label3.Text = "ژمارەی پسوڵە";
            // 
            // button2
            // 
            button2.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Teal;
            button2.Location = new Point(1200, 94);
            button2.Name = "button2";
            button2.Size = new Size(113, 33);
            button2.TabIndex = 58;
            button2.Text = "گەڕان";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ProductSelection
            // 
            ProductSelection.AutoCompleteMode = AutoCompleteMode.Suggest;
            ProductSelection.AutoCompleteSource = AutoCompleteSource.ListItems;
            ProductSelection.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductSelection.FormattingEnabled = true;
            ProductSelection.Location = new Point(1378, 405);
            ProductSelection.Name = "ProductSelection";
            ProductSelection.Size = new Size(235, 33);
            ProductSelection.TabIndex = 59;
            ProductSelection.SelectedIndexChanged += ProductSelection_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(1559, 363);
            label1.Name = "label1";
            label1.Size = new Size(54, 39);
            label1.TabIndex = 60;
            label1.Text = "کاڵا";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown1.Location = new Point(1271, 405);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(101, 33);
            numericUpDown1.TabIndex = 62;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Teal;
            label2.Location = new Point(1314, 363);
            label2.Name = "label2";
            label2.Size = new Size(58, 39);
            label2.TabIndex = 61;
            label2.Text = "دانە";
            // 
            // addtolist
            // 
            addtolist.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addtolist.ForeColor = Color.Teal;
            addtolist.Location = new Point(1115, 405);
            addtolist.Name = "addtolist";
            addtolist.Size = new Size(150, 33);
            addtolist.TabIndex = 63;
            addtolist.Text = "زیادکردن بۆ گەڕانەوە";
            addtolist.UseVisualStyleBackColor = true;
            addtolist.Click += addtolist_Click;
            // 
            // button3
            // 
            button3.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Teal;
            button3.Location = new Point(3, 723);
            button3.Name = "button3";
            button3.Size = new Size(292, 33);
            button3.TabIndex = 64;
            button3.Text = "سڕینەوە";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Teal;
            button4.Location = new Point(1321, 723);
            button4.Name = "button4";
            button4.Size = new Size(292, 33);
            button4.TabIndex = 65;
            button4.Text = "گەڕانەوە";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // ReturnAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(addtolist);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ProductSelection);
            Controls.Add(button2);
            Controls.Add(ExpenseAmount);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label7);
            Name = "ReturnAdmin";
            Size = new Size(1616, 1029);
            Load += ReturnAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private DataGridView dataGridView1;
        private Button button1;
        private DataGridView dataGridView2;
        private TextBox ExpenseAmount;
        private Label label3;
        private Button button2;
        private ComboBox ProductSelection;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Button addtolist;
        private Button button3;
        private Button button4;
    }
}
