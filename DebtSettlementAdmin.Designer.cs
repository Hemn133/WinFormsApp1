namespace WinFormsApp1
{
    partial class DebtSettlementAdmin
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
            button10 = new Button();
            button11 = new Button();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            label3 = new Label();
            CustomerName = new ComboBox();
            AmountPaid = new TextBox();
            label1 = new Label();
            DatePaid = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(658, 0);
            label7.Name = "label7";
            label7.Size = new Size(324, 69);
            label7.TabIndex = 56;
            label7.Text = "گەڕانەوەی قەرز";
            // 
            // button10
            // 
            button10.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.Teal;
            button10.Location = new Point(1253, 184);
            button10.Name = "button10";
            button10.Size = new Size(336, 35);
            button10.TabIndex = 53;
            button10.Text = "زیادکردن";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.Red;
            button11.Location = new Point(968, 184);
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Teal;
            label5.Location = new Point(818, 103);
            label5.Name = "label5";
            label5.Size = new Size(77, 39);
            label5.TabIndex = 49;
            label5.Text = "بەروار";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(1394, 103);
            label3.Name = "label3";
            label3.Size = new Size(195, 39);
            label3.TabIndex = 48;
            label3.Text = "ناوی خاوەن قەرز";
            // 
            // CustomerName
            // 
            CustomerName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CustomerName.FormattingEnabled = true;
            CustomerName.Location = new Point(1253, 145);
            CustomerName.Name = "CustomerName";
            CustomerName.Size = new Size(336, 33);
            CustomerName.TabIndex = 57;
            // 
            // AmountPaid
            // 
            AmountPaid.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AmountPaid.Location = new Point(901, 145);
            AmountPaid.Multiline = true;
            AmountPaid.Name = "AmountPaid";
            AmountPaid.Size = new Size(346, 33);
            AmountPaid.TabIndex = 58;
            AmountPaid.TextChanged += AmountPaid_TextChanged;
            AmountPaid.KeyPress += AmountPaid_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(1107, 103);
            label1.Name = "label1";
            label1.Size = new Size(140, 39);
            label1.TabIndex = 59;
            label1.Text = "بڕی پارەدان";
            // 
            // DatePaid
            // 
            DatePaid.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatePaid.Format = DateTimePickerFormat.Short;
            DatePaid.Location = new Point(616, 145);
            DatePaid.Name = "DatePaid";
            DatePaid.Size = new Size(279, 33);
            DatePaid.TabIndex = 60;
            // 
            // DebtSettlementAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DatePaid);
            Controls.Add(label1);
            Controls.Add(AmountPaid);
            Controls.Add(CustomerName);
            Controls.Add(label7);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(label3);
            Name = "DebtSettlementAdmin";
            Size = new Size(1616, 1029);
            Load += DebtSettlementAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Button button10;
        private Button button11;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label3;
        private ComboBox CustomerName;
        private TextBox AmountPaid;
        private Label label1;
        private DateTimePicker DatePaid;
    }
}
