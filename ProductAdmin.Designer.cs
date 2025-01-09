namespace WinFormsApp1
{
    partial class ProductAdmin
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
            ProductName = new TextBox();
            SalePrice = new TextBox();
            PurchasePrice = new TextBox();
            button10 = new Button();
            button9 = new Button();
            button11 = new Button();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            Quantity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(455, 3);
            label7.Name = "label7";
            label7.Size = new Size(115, 69);
            label7.TabIndex = 34;
            label7.Text = "کۆگا";
            // 
            // ProductName
            // 
            ProductName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductName.Location = new Point(729, 140);
            ProductName.Multiline = true;
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(250, 33);
            ProductName.TabIndex = 33;
            // 
            // SalePrice
            // 
            SalePrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SalePrice.Location = new Point(247, 140);
            SalePrice.Multiline = true;
            SalePrice.Name = "SalePrice";
            SalePrice.Size = new Size(235, 33);
            SalePrice.TabIndex = 32;
            // 
            // PurchasePrice
            // 
            PurchasePrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PurchasePrice.Location = new Point(488, 140);
            PurchasePrice.Multiline = true;
            PurchasePrice.Name = "PurchasePrice";
            PurchasePrice.Size = new Size(235, 33);
            PurchasePrice.TabIndex = 31;
            // 
            // button10
            // 
            button10.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.Teal;
            button10.Location = new Point(643, 184);
            button10.Name = "button10";
            button10.Size = new Size(336, 35);
            button10.TabIndex = 30;
            button10.Text = "زیادکردن";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.Teal;
            button9.Location = new Point(291, 184);
            button9.Name = "button9";
            button9.Size = new Size(346, 35);
            button9.TabIndex = 29;
            button9.Text = "گۆڕانکاری";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button11
            // 
            button11.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.Red;
            button11.Location = new Point(6, 184);
            button11.Name = "button11";
            button11.Size = new Size(279, 35);
            button11.TabIndex = 28;
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
            dataGridView1.Location = new Point(3, 225);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(981, 415);
            dataGridView1.TabIndex = 27;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Teal;
            label6.Location = new Point(184, 98);
            label6.Name = "label6";
            label6.Size = new Size(58, 39);
            label6.TabIndex = 26;
            label6.Text = "دانە";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Teal;
            label5.Location = new Point(594, 98);
            label5.Name = "label5";
            label5.Size = new Size(129, 39);
            label5.TabIndex = 25;
            label5.Text = "نرخی کڕین";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Teal;
            label4.Location = new Point(315, 98);
            label4.Name = "label4";
            label4.Size = new Size(167, 39);
            label4.TabIndex = 24;
            label4.Text = "نرخی فرۆشتن";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(867, 98);
            label3.Name = "label3";
            label3.Size = new Size(112, 39);
            label3.TabIndex = 23;
            label3.Text = "ناوی کاڵا";
            // 
            // Quantity
            // 
            Quantity.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Quantity.Location = new Point(6, 140);
            Quantity.Multiline = true;
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(235, 33);
            Quantity.TabIndex = 22;
            // 
            // ProductAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(ProductName);
            Controls.Add(SalePrice);
            Controls.Add(PurchasePrice);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button11);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Quantity);
            Name = "ProductAdmin";
            Size = new Size(986, 642);
            Load += ProductAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox ProductName;
        private TextBox SalePrice;
        private TextBox PurchasePrice;
        private Button button10;
        private Button button9;
        private Button button11;
        private DataGridView dataGridView1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox Quantity;
    }
}
