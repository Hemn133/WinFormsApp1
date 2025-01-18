namespace WinFormsApp1
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Role = new ComboBox();
            Password = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(905, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 45);
            label1.TabIndex = 0;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(358, 9);
            label2.Name = "label2";
            label2.Size = new Size(273, 69);
            label2.TabIndex = 1;
            label2.Text = "چونەژوورەوە";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(551, 244);
            label3.Name = "label3";
            label3.Size = new Size(122, 53);
            label3.TabIndex = 2;
            label3.Text = "هەژمار";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("NRT Bold", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(551, 305);
            label4.Name = "label4";
            label4.Size = new Size(221, 53);
            label4.TabIndex = 3;
            label4.Text = "وشەی نهێنی";
            // 
            // Role
            // 
            Role.DropDownStyle = ComboBoxStyle.DropDownList;
            Role.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Role.FormattingEnabled = true;
            Role.Items.AddRange(new object[] { "Admin", "Employee" });
            Role.Location = new Point(358, 238);
            Role.Name = "Role";
            Role.Size = new Size(187, 55);
            Role.TabIndex = 4;
            // 
            // Password
            // 
            Password.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Password.Location = new Point(358, 299);
            Password.Multiline = true;
            Password.Name = "Password";
            Password.PasswordChar = '•';
            Password.Size = new Size(187, 55);
            Password.TabIndex = 5;
            Password.TextChanged += Password_TextChanged;
            Password.KeyDown += Password_KeyDown;
            // 
            // button1
            // 
            button1.Font = new Font("NRT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Teal;
            button1.Location = new Point(358, 420);
            button1.Name = "button1";
            button1.Size = new Size(187, 55);
            button1.TabIndex = 6;
            button1.Text = "چونەژوورەوە";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("NRT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(358, 360);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(131, 22);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "بینینی وشەی نهێنی";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(358, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(273, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(956, 520);
            Controls.Add(pictureBox1);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(Password);
            Controls.Add(Role);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox Role;
        private TextBox Password;
        private Button button1;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
    }
}
