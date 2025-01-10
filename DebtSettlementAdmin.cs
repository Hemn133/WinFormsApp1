﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DebtSettlementAdmin : UserControl
    {
        public DebtSettlementAdmin()
        {
            InitializeComponent();
        }

        private void DebtSettlementAdmin_Load(object sender, EventArgs e)
        {
            DB db = new DB(); // Create an instance of the DB class

            // Query to load customer names for the ComboBox
            string query = "SELECT CustomerID, CustomerName FROM Customer";
            DataTable dataTable = db.GetDataTable(query);
            CustomerName.DataSource = dataTable;
            CustomerName.DisplayMember = "CustomerName";
            CustomerName.ValueMember = "CustomerID";

            // Query to load the debt settlement data into the DataGridView
            string settlementQuery = @"
        SELECT 
    ds.DebtSettlementID, 
    c.CustomerName, 
    ds.AmountPaid, 
    ds.PaymentDate
FROM DebtSettlement ds
JOIN Customer c ON ds.CustomerID = c.CustomerID";

            DataTable settlementData = db.GetDataTable(settlementQuery);
            dataGridView1.DataSource = settlementData; // Bind the data to the DataGridView

            dataGridView1.Columns["CustomerName"].HeaderText = "ناوی خاوەن قەرز";  // Renaming column to "Customer Name"
            dataGridView1.Columns["AmountPaid"].HeaderText = "بڕی پارەدان";  // Renaming column to "Amount Paid"
            dataGridView1.Columns["PaymentDate"].HeaderText = "بەرواری پارەدان";  // Renaming column to "Payment Date"


            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("NRT Bold", 12, FontStyle.Regular); // Adjust size if needed
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal; // Set background color to teal
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Set text color to white for better contrast
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            ReverseColumnsOrder(dataGridView1);







        }
        private void ReverseColumnsOrder(DataGridView dataGridView)
        {
            int columnCount = dataGridView.Columns.Count;

            for (int i = 0; i < columnCount; i++)
            {
                dataGridView.Columns[i].DisplayIndex = columnCount - 1 - i;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            string customerId = CustomerName.SelectedValue.ToString(); // Get the selected CustomerID
            string amountText = AmountPaid.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(amountText))
            {
                MessageBox.Show("Please enter all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid settlement amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize the DB class
            DB db = new DB();

            try
            {
                // 1. Insert into the DebtSettlement table
                string insertQuery = "INSERT INTO DebtSettlement (CustomerID,UserAccountID, AmountPaid, PaymentDate) VALUES (@CustomerID,1, @Amount, @SettlementDate)";
                Dictionary<string, object> insertParams = new Dictionary<string, object>
        {
            { "@CustomerID", customerId },
            { "@Amount", amount },
            { "@SettlementDate", DateTime.Now } // Current date and time
        };
                db.ExecuteWithParameters(insertQuery, insertParams);

                // 2. Update the TotalDebt in the Customer table
                string updateQuery = "UPDATE Customer SET TotalDebt = TotalDebt - @Amount WHERE CustomerID = @CustomerID";
                Dictionary<string, object> updateParams = new Dictionary<string, object>
        {
            { "@CustomerID", customerId },
            { "@Amount", amount }
        };
                db.ExecuteWithParameters(updateQuery, updateParams);

                // Show success message
                MessageBox.Show("Debt settlement recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields
                AmountPaid.Clear();
                CustomerName.SelectedIndex = -1; // Reset the combobox

                // Refresh the DataGridView to display the new settlement
                string settlementQuery = @"
            SELECT 
                ds.DebtSettlementID,
                c.CustomerName, 
                ds.AmountPaid, 
                ds.PaymentDate 
            FROM DebtSettlement ds
            JOIN Customer c ON ds.CustomerID = c.CustomerID";

                DataTable settlementData = db.GetDataTable(settlementQuery);
                dataGridView1.DataSource = settlementData; // Update DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Get the selected row
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve the settlement ID to delete
            int settlementId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DebtSettlementID"].Value);

            // Initialize the DB class
            DB db = new DB();

            // Step 1: Retrieve the amount paid in the settlement
            string selectQuery = "SELECT AmountPaid, CustomerID FROM DebtSettlement WHERE DebtSettlementID = @SettlementID";
            Dictionary<string, object> selectParams = new Dictionary<string, object>
    {
        { "@SettlementID", settlementId }
    };

            DataTable settlementData = db.GetDataTable(selectQuery, selectParams);

            if (settlementData.Rows.Count == 0)
            {
                MessageBox.Show("Settlement not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal amountPaid = Convert.ToDecimal(settlementData.Rows[0]["AmountPaid"]);
            string customerId = settlementData.Rows[0]["CustomerID"].ToString();

            // Step 2: Ask for confirmation before deleting
            DialogResult result = MessageBox.Show("Are you sure you want to delete this settlement?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Step 3: Delete the settlement from the database
                string deleteQuery = "DELETE FROM DebtSettlement WHERE DebtSettlementID = @SettlementID";
                db.ExecuteWithParameters(deleteQuery, new Dictionary<string, object> { { "@SettlementID", settlementId } });

                // Step 4: Update the Customer's TotalDebt by adding back the amount
                string updateQuery = "UPDATE Customer SET TotalDebt = TotalDebt + @Amount WHERE CustomerID = @CustomerID";
                Dictionary<string, object> updateParams = new Dictionary<string, object>
        {
            { "@CustomerID", customerId },
            { "@Amount", amountPaid }
        };
                db.ExecuteWithParameters(updateQuery, updateParams);

                // Refresh the DataGridView
                RefreshDataGridView();

                MessageBox.Show("Debt settlement deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshDataGridView()
        {
            // Your DB class instance
            DB db = new DB();

            // Modify the query to include DebtSettlementID
            string query = @"
    SELECT 
        ds.DebtSettlementID,      -- Add DebtSettlementID
        c.CustomerName, 
        ds.AmountPaid, 
        ds.PaymentDate 
    FROM DebtSettlement ds
    JOIN Customer c ON ds.CustomerID = c.CustomerID";

            // Execute the query and get the result as a DataTable
            DataTable dataTable = db.GetDataTable(query);

            // Set the DataGridView's data source
            dataGridView1.DataSource = dataTable;

            // Add DebtSettlementID column if it doesn't exist already (make it hidden)
            if (!dataGridView1.Columns.Contains("DebtSettlementID"))
            {
                DataGridViewColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.Name = "DebtSettlementID";
                idColumn.HeaderText = "Debt Settlement ID";  // You can change this to your language
                idColumn.Visible = false;  // Set it as hidden
                dataGridView1.Columns.Add(idColumn);
            }

            // Additional DataGridView styling and customization
            dataGridView1.Columns["CustomerName"].HeaderText = "ناوی خاوەن قەرز";
            dataGridView1.Columns["AmountPaid"].HeaderText = "بڕی پارەدان";
            dataGridView1.Columns["PaymentDate"].HeaderText = "بەرواری پارەدان";

            // Style settings
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("NRT Bold", 12, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            ReverseColumnsOrder(dataGridView1);
        }
    }
}

