﻿namespace WinFormsApp1
{
    partial class CustomerAdmin
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
            PurchasePrice = new TextBox();
            button10 = new Button();
            button9 = new Button();
            button11 = new Button();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(354, 0);
            label7.Name = "label7";
            label7.Size = new Size(334, 69);
            label7.TabIndex = 47;
            label7.Text = "خاوەن قەرزەکان";
            // 
            // ProductName
            // 
            ProductName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductName.Location = new Point(729, 140);
            ProductName.Multiline = true;
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(250, 33);
            ProductName.TabIndex = 46;
            // 
            // PurchasePrice
            // 
            PurchasePrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PurchasePrice.Location = new Point(6, 140);
            PurchasePrice.Multiline = true;
            PurchasePrice.Name = "PurchasePrice";
            PurchasePrice.Size = new Size(235, 33);
            PurchasePrice.TabIndex = 44;
            // 
            // button10
            // 
            button10.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.Teal;
            button10.Location = new Point(643, 184);
            button10.Name = "button10";
            button10.Size = new Size(336, 35);
            button10.TabIndex = 43;
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
            button9.TabIndex = 42;
            button9.Text = "گۆڕانکاری";
            button9.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.Red;
            button11.Location = new Point(6, 184);
            button11.Name = "button11";
            button11.Size = new Size(279, 35);
            button11.TabIndex = 41;
            button11.Text = "سڕینەوە";
            button11.UseVisualStyleBackColor = true;
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
            dataGridView1.TabIndex = 40;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Teal;
            label5.Location = new Point(131, 98);
            label5.Name = "label5";
            label5.Size = new Size(110, 39);
            label5.TabIndex = 38;
            label5.Text = "بڕی قەرز";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(784, 98);
            label3.Name = "label3";
            label3.Size = new Size(195, 39);
            label3.TabIndex = 36;
            label3.Text = "ناوی خاوەن قەرز";
            // 
            // CustomerAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(ProductName);
            Controls.Add(PurchasePrice);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button11);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(label3);
            Name = "CustomerAdmin";
            Size = new Size(986, 642);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox ProductName;
        private TextBox PurchasePrice;
        private Button button10;
        private Button button9;
        private Button button11;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label3;
    }
}
