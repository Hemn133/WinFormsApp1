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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Location = new Point(472, 199);
            panel1.Name = "panel1";
            panel1.Size = new Size(986, 642);
            panel1.TabIndex = 2;
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
            button1.Click += button1_Click;
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
            button2.Click += button2_Click;
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
            button3.Click += button3_Click;
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
            button4.Click += button4_Click;
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
            button5.Click += button5_Click;
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
            button6.Click += button6_Click;
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
            button7.Click += button7_Click;
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
    }
}