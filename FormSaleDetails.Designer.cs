namespace WinFormsApp1
{
    partial class FormSaleDetails
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
            dataGridViewSaleDetails = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSaleDetails).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSaleDetails
            // 
            dataGridViewSaleDetails.AllowUserToAddRows = false;
            dataGridViewSaleDetails.AllowUserToDeleteRows = false;
            dataGridViewSaleDetails.AllowUserToResizeColumns = false;
            dataGridViewSaleDetails.AllowUserToResizeRows = false;
            dataGridViewSaleDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSaleDetails.Location = new Point(12, 12);
            dataGridViewSaleDetails.Name = "dataGridViewSaleDetails";
            dataGridViewSaleDetails.ReadOnly = true;
            dataGridViewSaleDetails.Size = new Size(776, 426);
            dataGridViewSaleDetails.TabIndex = 0;
            dataGridViewSaleDetails.CellFormatting += dataGridViewSaleDetails_CellFormatting;
            // 
            // FormSaleDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 445);
            Controls.Add(dataGridViewSaleDetails);
            Name = "FormSaleDetails";
            Text = "FormSaleDetails";
            Load += FormSaleDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSaleDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewSaleDetails;
    }
}