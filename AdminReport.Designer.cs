namespace WinFormsApp1
{
    partial class AdminReport
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
            dataGridViewReports = new DataGridView();
            StartDatePicker = new DateTimePicker();
            label6 = new Label();
            EndDatePicker = new DateTimePicker();
            button2 = new Button();
            txtTotalCashSales = new TextBox();
            txtTotalExpenses = new TextBox();
            txtTotalDebtSales = new TextBox();
            txtTotalDebtSettlements = new TextBox();
            txtNetTotal = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("NRT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(697, 0);
            label7.Name = "label7";
            label7.Size = new Size(222, 69);
            label7.TabIndex = 49;
            label7.Text = "ڕاپۆرتەکان";
            // 
            // dataGridViewReports
            // 
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.AllowUserToDeleteRows = false;
            dataGridViewReports.AllowUserToResizeColumns = false;
            dataGridViewReports.AllowUserToResizeRows = false;
            dataGridViewReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReports.Location = new Point(3, 186);
            dataGridViewReports.Name = "dataGridViewReports";
            dataGridViewReports.ReadOnly = true;
            dataGridViewReports.Size = new Size(1610, 701);
            dataGridViewReports.TabIndex = 50;
            dataGridViewReports.CellFormatting += dataGridViewReports_CellFormatting;
            // 
            // StartDatePicker
            // 
            StartDatePicker.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartDatePicker.CustomFormat = "dd-MM-yyyy";
            StartDatePicker.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartDatePicker.Format = DateTimePickerFormat.Short;
            StartDatePicker.Location = new Point(1413, 147);
            StartDatePicker.Name = "StartDatePicker";
            StartDatePicker.Size = new Size(200, 33);
            StartDatePicker.TabIndex = 57;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("NRT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Teal;
            label6.Location = new Point(1376, 150);
            label6.Name = "label6";
            label6.Size = new Size(31, 30);
            label6.TabIndex = 59;
            label6.Text = "بۆ";
            // 
            // EndDatePicker
            // 
            EndDatePicker.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndDatePicker.CustomFormat = "dd-MM-yyyy";
            EndDatePicker.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndDatePicker.Format = DateTimePickerFormat.Short;
            EndDatePicker.Location = new Point(1170, 147);
            EndDatePicker.Name = "EndDatePicker";
            EndDatePicker.Size = new Size(200, 33);
            EndDatePicker.TabIndex = 60;
            // 
            // button2
            // 
            button2.Font = new Font("NRT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Teal;
            button2.Location = new Point(1074, 146);
            button2.Name = "button2";
            button2.Size = new Size(90, 34);
            button2.TabIndex = 61;
            button2.Text = "گەڕان";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtTotalCashSales
            // 
            txtTotalCashSales.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalCashSales.Location = new Point(1346, 971);
            txtTotalCashSales.Multiline = true;
            txtTotalCashSales.Name = "txtTotalCashSales";
            txtTotalCashSales.ReadOnly = true;
            txtTotalCashSales.Size = new Size(267, 55);
            txtTotalCashSales.TabIndex = 62;
            txtTotalCashSales.TextAlign = HorizontalAlignment.Center;
            txtTotalCashSales.TextChanged += txtTotalCashSales_TextChanged;
            // 
            // txtTotalExpenses
            // 
            txtTotalExpenses.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalExpenses.Location = new Point(527, 971);
            txtTotalExpenses.Multiline = true;
            txtTotalExpenses.Name = "txtTotalExpenses";
            txtTotalExpenses.ReadOnly = true;
            txtTotalExpenses.Size = new Size(267, 55);
            txtTotalExpenses.TabIndex = 63;
            txtTotalExpenses.TextAlign = HorizontalAlignment.Center;
            txtTotalExpenses.TextChanged += txtTotalExpenses_TextChanged;
            // 
            // txtTotalDebtSales
            // 
            txtTotalDebtSales.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalDebtSales.Location = new Point(1073, 971);
            txtTotalDebtSales.Multiline = true;
            txtTotalDebtSales.Name = "txtTotalDebtSales";
            txtTotalDebtSales.ReadOnly = true;
            txtTotalDebtSales.Size = new Size(267, 55);
            txtTotalDebtSales.TabIndex = 64;
            txtTotalDebtSales.TextAlign = HorizontalAlignment.Center;
            txtTotalDebtSales.TextChanged += txtTotalDebtSales_TextChanged;
            // 
            // txtTotalDebtSettlements
            // 
            txtTotalDebtSettlements.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalDebtSettlements.Location = new Point(800, 971);
            txtTotalDebtSettlements.Multiline = true;
            txtTotalDebtSettlements.Name = "txtTotalDebtSettlements";
            txtTotalDebtSettlements.ReadOnly = true;
            txtTotalDebtSettlements.Size = new Size(267, 55);
            txtTotalDebtSettlements.TabIndex = 65;
            txtTotalDebtSettlements.TextAlign = HorizontalAlignment.Center;
            txtTotalDebtSettlements.TextChanged += txtTotalDebtSettlements_TextChanged;
            // 
            // txtNetTotal
            // 
            txtNetTotal.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNetTotal.Location = new Point(3, 971);
            txtNetTotal.Multiline = true;
            txtNetTotal.Name = "txtNetTotal";
            txtNetTotal.ReadOnly = true;
            txtNetTotal.Size = new Size(267, 55);
            txtNetTotal.TabIndex = 66;
            txtNetTotal.TextAlign = HorizontalAlignment.Center;
            txtNetTotal.TextChanged += txtNetTotal_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Teal;
            label4.Location = new Point(1413, 890);
            label4.Name = "label4";
            label4.Size = new Size(166, 78);
            label4.TabIndex = 67;
            label4.Text = "کۆی فرۆشراو\r\n     (کاش)\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(67, 929);
            label1.Name = "label1";
            label1.Size = new Size(135, 39);
            label1.TabIndex = 68;
            label1.Text = "پاشەکەوت";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Teal;
            label2.Location = new Point(826, 929);
            label2.Name = "label2";
            label2.Size = new Size(217, 39);
            label2.TabIndex = 69;
            label2.Text = "کۆی گەڕاوەی قەرز";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(581, 929);
            label3.Name = "label3";
            label3.Size = new Size(145, 39);
            label3.TabIndex = 70;
            label3.Text = "کۆی خەرجی";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("NRT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Teal;
            label5.Location = new Point(1134, 890);
            label5.Name = "label5";
            label5.Size = new Size(166, 78);
            label5.TabIndex = 71;
            label5.Text = "کۆی فرۆشراو\r\n     (قەرز)";
            // 
            // AdminReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(txtNetTotal);
            Controls.Add(txtTotalDebtSettlements);
            Controls.Add(txtTotalDebtSales);
            Controls.Add(txtTotalExpenses);
            Controls.Add(txtTotalCashSales);
            Controls.Add(button2);
            Controls.Add(EndDatePicker);
            Controls.Add(label6);
            Controls.Add(StartDatePicker);
            Controls.Add(dataGridViewReports);
            Controls.Add(label7);
            Name = "AdminReport";
            Size = new Size(1616, 1029);
            Load += AdminReport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private DataGridView dataGridViewReports;
        private DateTimePicker StartDatePicker;
        private Label label6;
        private DateTimePicker EndDatePicker;
        private Button button2;
        private TextBox txtTotalCashSales;
        private TextBox txtTotalExpenses;
        private TextBox txtTotalDebtSales;
        private TextBox txtTotalDebtSettlements;
        private TextBox txtNetTotal;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
    }
}
