namespace WinFormsApp1
{
    partial class AdminSelling
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
            ProductSelection = new ComboBox();
            addtolist = new Button();
            dataGridView1 = new DataGridView();
            isdebt = new CheckBox();
            save = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            dataGridView2 = new DataGridView();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label6 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(626, 0);
            label7.Name = "label7";
            label7.Size = new Size(290, 69);
            label7.TabIndex = 37;
            label7.Text = "فرۆشتنی کاڵا";
            // 
            // ProductSelection
            // 
            ProductSelection.AutoCompleteMode = AutoCompleteMode.Suggest;
            ProductSelection.AutoCompleteSource = AutoCompleteSource.ListItems;
            ProductSelection.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductSelection.FormattingEnabled = true;
            ProductSelection.Location = new Point(1378, 154);
            ProductSelection.Name = "ProductSelection";
            ProductSelection.Size = new Size(235, 33);
            ProductSelection.TabIndex = 0;
            ProductSelection.SelectedIndexChanged += ProductSelection_SelectedIndexChanged;
            // 
            // addtolist
            // 
            addtolist.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addtolist.ForeColor = Color.Teal;
            addtolist.Location = new Point(1126, 154);
            addtolist.Name = "addtolist";
            addtolist.Size = new Size(139, 33);
            addtolist.TabIndex = 2;
            addtolist.Text = "زیادکردن بۆ پسوڵە";
            addtolist.UseVisualStyleBackColor = true;
            addtolist.Click += addtolist_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1126, 267);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(487, 713);
            dataGridView1.TabIndex = 41;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // isdebt
            // 
            isdebt.AutoSize = true;
            isdebt.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            isdebt.ForeColor = Color.Teal;
            isdebt.Location = new Point(1551, 193);
            isdebt.Name = "isdebt";
            isdebt.Size = new Size(62, 31);
            isdebt.TabIndex = 3;
            isdebt.Text = "قەرز";
            isdebt.UseVisualStyleBackColor = true;
            isdebt.CheckedChanged += isdebt_CheckedChanged;
            // 
            // save
            // 
            save.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            save.ForeColor = Color.Teal;
            save.Location = new Point(1126, 227);
            save.Name = "save";
            save.Size = new Size(487, 34);
            save.TabIndex = 5;
            save.Text = "فرۆشتن";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(1559, 112);
            label1.Name = "label1";
            label1.Size = new Size(54, 39);
            label1.TabIndex = 44;
            label1.Text = "کاڵا";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Teal;
            label2.Location = new Point(1314, 112);
            label2.Name = "label2";
            label2.Size = new Size(58, 39);
            label2.TabIndex = 45;
            label2.Text = "دانە";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(1514, 993);
            label3.Name = "label3";
            label3.Size = new Size(99, 27);
            label3.TabIndex = 46;
            label3.Text = "کۆی گشتی";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(1292, 987);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(216, 33);
            textBox1.TabIndex = 47;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.ItemHeight = 21;
            comboBox1.Location = new Point(1126, 192);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(235, 29);
            comboBox1.TabIndex = 49;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Teal;
            label5.Location = new Point(1367, 194);
            label5.Name = "label5";
            label5.Size = new Size(95, 27);
            label5.TabIndex = 50;
            label5.Text = "خاوەن قەرز";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown1.Location = new Point(1271, 154);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(101, 33);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Teal;
            button1.Location = new Point(1126, 987);
            button1.Name = "button1";
            button1.Size = new Size(139, 33);
            button1.TabIndex = 6;
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
            dataGridView2.Location = new Point(3, 267);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Size = new Size(1117, 753);
            dataGridView2.TabIndex = 54;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.CellFormatting += dataGridView2_CellFormatting;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.WhiteSmoke;
            label4.Font = new Font("NRT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Teal;
            label4.Location = new Point(916, 214);
            label4.Name = "label4";
            label4.Size = new Size(189, 47);
            label4.TabIndex = 55;
            label4.Text = "فرۆشراوەکان";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(342, 232);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 33);
            dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(99, 232);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 33);
            dateTimePicker2.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("NRT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Teal;
            label6.Location = new Point(305, 233);
            label6.Name = "label6";
            label6.Size = new Size(31, 30);
            label6.TabIndex = 58;
            label6.Text = "بۆ";
            // 
            // button2
            // 
            button2.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Teal;
            button2.Location = new Point(3, 231);
            button2.Name = "button2";
            button2.Size = new Size(90, 34);
            button2.TabIndex = 9;
            button2.Text = "گەڕان";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AdminSelling
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(save);
            Controls.Add(isdebt);
            Controls.Add(dataGridView1);
            Controls.Add(addtolist);
            Controls.Add(ProductSelection);
            Controls.Add(label7);
            Name = "AdminSelling";
            Size = new Size(1616, 1029);
            Load += AdminSelling_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private ComboBox ProductSelection;
        private Button addtolist;
        private DataGridView dataGridView1;
        private CheckBox isdebt;
        private Button save;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private DataGridView dataGridView2;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label6;
        private Button button2;
    }
}
