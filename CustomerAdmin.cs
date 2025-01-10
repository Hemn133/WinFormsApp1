using System;
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
    public partial class CustomerAdmin : UserControl
    {
        public CustomerAdmin()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            string customername = CustomerName.Text.Trim();
            string amount = Amount.Text.Trim();


            // Validate input
            if (string.IsNullOrEmpty(customername) ||
                string.IsNullOrEmpty(amount))


            {
                MessageBox.Show("تکایە زانیاری کاڵای نوێ دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize the DB class
            DB db = new DB();

            if (db.DoesProductExist(customername))
            {
                MessageBox.Show("ئەم ناوە پێشتر تۆمار کراوە!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Define the table name and columns
            string tableName = "Customer";
            string[] columns = { "CustomerName", "TotalDebt" };
            string[] values = { customername, amount };

            // Call the CreateByParameters method
            try
            {
                db.CreateByParameters(tableName, columns, values);
                MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                CustomerName.Clear();
                Amount.Clear();

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
            string query = "SELECT * FROM Customer"; // Replace with your actual query
            DataTable dataTable = db.GetDataTable(query);
            dataGridView1.DataSource = dataTable;

            // Adjust column settings if needed
            dataGridView1.Columns["CustomerID"].Visible = false;
            dataGridView1.Columns["CustomerName"].HeaderText = "دانە";
            dataGridView1.Columns["TotalDebt"].HeaderText = "ناوی کاڵا";
            ReverseColumnsOrder(dataGridView1);
        }

        private void CustomerAdmin_Load(object sender, EventArgs e)
        {
            DB db = new DB(); // Create an instance of the DB class
            string query = "SELECT * FROM Customer"; // Replace with your actual query

            // Retrieve data using the DB class
            DataTable dataTable = db.GetDataTable(query);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable; // Replace 'dataGridView1' with the name of your DataGridView

            dataGridView1.Columns["CustomerID"].Visible = false;
            dataGridView1.Columns["CustomerName"].HeaderText = "ناو";
            dataGridView1.Columns["TotalDebt"].HeaderText = "بڕی پارە";

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("NRT Bold", 12, FontStyle.Regular); // Adjust size if needed
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal; // Set background color to teal
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Set text color to white for better contrast
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            ReverseColumnsOrder(dataGridView1);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Amount.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Delete selected customer
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("تکایە کەسێک هەڵبژێرە بۆ سڕینەوە", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string customerName = selectedRow.Cells["CustomerName"].Value.ToString();

            DB db = new DB();

            string query = "DELETE FROM Customer WHERE CustomerName = @CustomerName";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerName", customerName }
            };

            try
            {
                db.ExecuteWithParameters(query, parameters);
                MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            { MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }



            

            RefreshDataGridView();

            CustomerName.Clear();
            Amount.Clear();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("تکایە کەسێک هەڵبژێرە بۆ گۆڕین", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string originalCustomerName = selectedRow.Cells["CustomerName"].Value.ToString();
            string newCustomerName = CustomerName.Text.Trim();
            string amount = Amount.Text.Trim();



            // Validate input
            if (string.IsNullOrEmpty(newCustomerName) ||
                string.IsNullOrEmpty(amount))
            {
                MessageBox.Show("تکایە ناوی خاوەن قەرز دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DB db = new DB();

            string query = "UPDATE Customer SET CustomerName = @NewCustomerName, TotalDebt = @TotalDebt WHERE CustomerName = @OriginalCustomerName";

            // Prepare parameters
            var parameters = new Dictionary<string, object>
            {
                { "@NewCustomerName", newCustomerName },
                { "@TotalDebt", amount },
                { "@OriginalCustomerName", originalCustomerName }
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
    }
}

