namespace WinFormsApp1
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            panel1 = new Panel();
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(ProductName);
            panel1.Controls.Add(SalePrice);
            panel1.Controls.Add(PurchasePrice);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(Quantity);
            panel1.Location = new Point(477, 199);
            panel1.Name = "panel1";
            panel1.Size = new Size(981, 642);
            panel1.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(452, 5);
            label7.Name = "label7";
            label7.Size = new Size(115, 69);
            label7.TabIndex = 21;
            label7.Text = "کۆگا";
            // 
            // ProductName
            // 
            ProductName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductName.Location = new Point(726, 142);
            ProductName.Multiline = true;
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(250, 33);
            ProductName.TabIndex = 20;
            // 
            // SalePrice
            // 
            SalePrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SalePrice.Location = new Point(244, 142);
            SalePrice.Multiline = true;
            SalePrice.Name = "SalePrice";
            SalePrice.Size = new Size(235, 33);
            SalePrice.TabIndex = 19;
            // 
            // PurchasePrice
            // 
            PurchasePrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PurchasePrice.Location = new Point(485, 142);
            PurchasePrice.Multiline = true;
            PurchasePrice.Name = "PurchasePrice";
            PurchasePrice.Size = new Size(235, 33);
            PurchasePrice.TabIndex = 18;
            // 
            // button10
            // 
            button10.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.Teal;
            button10.Location = new Point(640, 186);
            button10.Name = "button10";
            button10.Size = new Size(336, 35);
            button10.TabIndex = 17;
            button10.Text = "زیادکردن";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.Teal;
            button9.Location = new Point(288, 186);
            button9.Name = "button9";
            button9.Size = new Size(346, 35);
            button9.TabIndex = 16;
            button9.Text = "گۆڕانکاری";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button11
            // 
            button11.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.Red;
            button11.Location = new Point(3, 186);
            button11.Name = "button11";
            button11.Size = new Size(279, 35);
            button11.TabIndex = 15;
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
            dataGridView1.Location = new Point(0, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(981, 415);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Teal;
            label6.Location = new Point(181, 100);
            label6.Name = "label6";
            label6.Size = new Size(58, 39);
            label6.TabIndex = 11;
            label6.Text = "دانە";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Teal;
            label5.Location = new Point(591, 100);
            label5.Name = "label5";
            label5.Size = new Size(129, 39);
            label5.TabIndex = 10;
            label5.Text = "نرخی کڕین";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Teal;
            label4.Location = new Point(312, 100);
            label4.Name = "label4";
            label4.Size = new Size(167, 39);
            label4.TabIndex = 9;
            label4.Text = "نرخی فرۆشتن";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(864, 100);
            label3.Name = "label3";
            label3.Size = new Size(112, 39);
            label3.TabIndex = 8;
            label3.Text = "ناوی کاڵا";
            // 
            // Quantity
            // 
            Quantity.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Quantity.Location = new Point(3, 142);
            Quantity.Multiline = true;
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(235, 33);
            Quantity.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Teal;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(1464, 288);
            button1.Name = "button1";
            button1.Size = new Size(243, 61);
            button1.TabIndex = 4;
            button1.Text = "کۆگا";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Teal;
            button2.Location = new Point(1464, 355);
            button2.Name = "button2";
            button2.Size = new Size(243, 61);
            button2.TabIndex = 5;
            button2.Text = "فرۆشتنی کاڵا";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Teal;
            button3.Location = new Point(1464, 422);
            button3.Name = "button3";
            button3.Size = new Size(243, 61);
            button3.TabIndex = 6;
            button3.Text = "گەڕانەوەی کاڵا";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Teal;
            button4.Location = new Point(1464, 489);
            button4.Name = "button4";
            button4.Size = new Size(243, 61);
            button4.TabIndex = 7;
            button4.Text = "خاوەن قەرزەکان";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.Teal;
            button5.Location = new Point(1464, 556);
            button5.Name = "button5";
            button5.Size = new Size(243, 61);
            button5.TabIndex = 8;
            button5.Text = "گەڕانەوەی قەرز";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Teal;
            button6.Location = new Point(1464, 623);
            button6.Name = "button6";
            button6.Size = new Size(243, 61);
            button6.TabIndex = 9;
            button6.Text = "خەرجی";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.Teal;
            button7.Location = new Point(1464, 690);
            button7.Name = "button7";
            button7.Size = new Size(243, 61);
            button7.TabIndex = 10;
            button7.Text = "ڕاپۆرتەکان";
            button7.TextAlign = ContentAlignment.MiddleRight;
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.Red;
            button8.Location = new Point(1464, 780);
            button8.Name = "button8";
            button8.Size = new Size(243, 61);
            button8.TabIndex = 11;
            button8.Text = "چونەدەرەوە";
            button8.TextAlign = ContentAlignment.MiddleRight;
            button8.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1464, 199);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(243, 88);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1940, 1100);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button5);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private PictureBox pictureBox1;
        private Label label3;
        private TextBox Quantity;
        private DataGridView dataGridView1;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox ProductName;
        private TextBox SalePrice;
        private TextBox PurchasePrice;
        private Button button10;
        private Button button9;
        private Button button11;
        private Label label7;
    }
}