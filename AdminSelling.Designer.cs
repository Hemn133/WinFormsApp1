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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            ProductSelection.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductSelection.FormattingEnabled = true;
            ProductSelection.Location = new Point(1378, 154);
            ProductSelection.Name = "ProductSelection";
            ProductSelection.Size = new Size(235, 33);
            ProductSelection.TabIndex = 38;
            // 
            // addtolist
            // 
            addtolist.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addtolist.ForeColor = Color.Teal;
            addtolist.Location = new Point(1126, 154);
            addtolist.Name = "addtolist";
            addtolist.Size = new Size(139, 33);
            addtolist.TabIndex = 40;
            addtolist.Text = "زیادکردن بۆ پسوڵە";
            addtolist.UseVisualStyleBackColor = true;
            addtolist.Click += addtolist_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1126, 230);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(487, 513);
            dataGridView1.TabIndex = 41;
            // 
            // isdebt
            // 
            isdebt.AutoSize = true;
            isdebt.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            isdebt.ForeColor = Color.Teal;
            isdebt.Location = new Point(1551, 193);
            isdebt.Name = "isdebt";
            isdebt.Size = new Size(62, 31);
            isdebt.TabIndex = 42;
            isdebt.Text = "قەرز";
            isdebt.UseVisualStyleBackColor = true;
            isdebt.CheckedChanged += isdebt_CheckedChanged;
            // 
            // save
            // 
            save.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            save.ForeColor = Color.Teal;
            save.Location = new Point(1126, 749);
            save.Name = "save";
            save.Size = new Size(160, 34);
            save.TabIndex = 43;
            save.Text = "تۆمارکردن";
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
            label3.Location = new Point(1514, 755);
            label3.Name = "label3";
            label3.Size = new Size(99, 27);
            label3.TabIndex = 46;
            label3.Text = "کۆی گشتی";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1292, 749);
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
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(101, 33);
            numericUpDown1.TabIndex = 52;
            // 
            // button1
            // 
            button1.Font = new Font("NRT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Teal;
            button1.Location = new Point(981, 304);
            button1.Name = "button1";
            button1.Size = new Size(139, 33);
            button1.TabIndex = 53;
            button1.Text = "سڕینەوە";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AdminSelling
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}
