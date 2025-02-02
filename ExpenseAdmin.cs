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
    public partial class ExpenseAdmin : UserControl
    {

        private string _userRole;
        public ExpenseAdmin(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;
        }

        private void ExpenseAdmin_Load(object sender, EventArgs e)
        {

            if (_userRole == "Employee")
            {

                ExpenseDatePicker.Enabled = false;
                button9.Enabled = false;
                button11.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;

            }

            ExpenseDateTextBox.Visible = false;
            DB db = new DB(); // Create an instance of the DB class
            string query = "SELECT * FROM Expenses"; // Replace with your actual query

            // Retrieve data using the DB class
            DataTable dataTable = db.GetDataTable(query);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable; // Replace 'dataGridView1' with the name of your DataGridView

            dataGridView1.Columns["ExpenseID"].Visible = false;
            dataGridView1.Columns["UserAccountID"].Visible = false;


            dataGridView1.Columns["Description"].HeaderText = "مەبەست";
            dataGridView1.Columns["ExpenseDate"].HeaderText = "بەروار";

            dataGridView1.Columns["Amount"].HeaderText = "بڕی خەرجی";
            ExpenseDateTextBox.Text = ExpenseDateTextBox.Text = DateTime.Now.ToString("");

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
            string expenseDate = ExpenseDatePicker.Text.Trim();
            string description = Description.Text.Trim();
            string amount = ExpenseAmount.Text.Trim();


            // Validate input
            if (string.IsNullOrEmpty(expenseDate) ||
                string.IsNullOrEmpty(description))


            {
                MessageBox.Show("تکایە زانیاری کاڵای نوێ دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize the DB class
            DB db = new DB();


            // Define the table name and columns
            string tableName = "Expenses";
            string[] columns = { "UserAccountID", "ExpenseDate", "Description", "Amount" };
            string[] values = { "1", expenseDate, description, amount };

            // Call the CreateByParameters method
            try
            {
                db.CreateByParameters(tableName, columns, values);
                MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                Description.Clear();
                ExpenseAmount.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshDataGridView();
        }



        private void RefreshDataGridView()
        {
            DB db = new DB();
            string query = "SELECT * FROM Expenses"; // Replace with your actual query
            DataTable dataTable = db.GetDataTable(query);
            dataGridView1.DataSource = dataTable;

            // Adjust column settings if needed
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Retrieve the hidden ExpenseID from the selected row
                int expenseId = Convert.ToInt32(selectedRow.Cells["ExpenseID"].Value);

                // Initialize the DB class
                DB db = new DB();

                // Delete the record using ExpenseID
                try
                {
                    db.DeleteById("Expenses", "ExpenseID", expenseId);

                    // Refresh the DataGridView after deletion
                    RefreshDataGridView();

                    MessageBox.Show("خەرجی سڕایەوە.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("تکایە خەرجی دیاری بکە بۆ سڕینەوە.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ExpenseAmount.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            ExpenseDateTextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Description.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string expenseamount = ExpenseAmount.Text.Trim();
            string description = Description.Text.Trim();
            string date = ExpenseDatePicker.Text.Trim();


            // Validate input
            if (
        string.IsNullOrEmpty(expenseamount) ||
        string.IsNullOrEmpty(description) ||
        string.IsNullOrEmpty(date))
            {
                MessageBox.Show("تکایە کاڵا دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Ensure a row is selected to get the ExpenseID
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("تکایە خەرجی دیاری بکە بۆ گۆڕانکاری.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected ExpenseID
            int expenseId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ExpenseID"].Value);

            DB db = new DB();

            string query = "UPDATE Expenses SET ExpenseDate = @ExpenseDate, Description = @Description, Amount = @Amount WHERE ExpenseID = @ExpenseID";

            // Prepare parameters
            var parameters = new Dictionary<string, object>
    {
        { "@ExpenseDate", date },
        { "@Description", description },
        { "@Amount", expenseamount },
        { "@ExpenseID", expenseId }
    };

            try
            {
                db.ExecuteWithParameters(query, parameters);
                MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExpenseAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Suppress the key if it's not a digit or control key
                e.Handled = true;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Amount" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Format the value as a thousand separator
                    e.Value = value.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve the selected dates from the DatePickers
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            // Validate that the start date is before the end date
            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after the end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Query the database for expenses between the selected dates
            string query = "SELECT * FROM Expenses WHERE ExpenseDate BETWEEN @StartDate AND @EndDate";

            // Prepare parameters for the query
            var parameters = new Dictionary<string, object>
    {
        { "@StartDate", startDate },
        { "@EndDate", endDate }
    };

            try
            {
                // Use your DB class to execute the query and get the result
                DB db = new DB();
                DataTable dataTable = db.GetDataTableWithParameters(query, parameters);

                // Bind the result to the DataGridView
                dataGridView1.DataSource = dataTable;

                // Optional: Show a message if no records are found
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No expenses found for the selected date range.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
