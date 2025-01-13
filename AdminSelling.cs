using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class AdminSelling : UserControl
    {
        DB db = new DB();
        public AdminSelling()
        {
            InitializeComponent();
        }

        public static int currentUserID = 1; // Replace this with the actual logic for retrieving the logged-in user's ID

        private void UpdateTotalAmount()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TotalPrice"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                }
            }

            textBox1.Text = total.ToString("0.00");
        }





        private void style(DataGridView datagridview)
        {
            datagridview.ColumnHeadersDefaultCellStyle.Font = new Font("NRT Bold", 12, FontStyle.Regular); // Adjust size if needed
            datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal; // Set background color to teal
            datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Set text color to white for better contrast
            datagridview.AllowUserToAddRows = false;
            datagridview.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            datagridview.RowTemplate.Height = 40;
            datagridview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridview.EnableHeadersVisualStyles = false;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            datagridview.RowsDefaultCellStyle.BackColor = Color.White;
            datagridview.BorderStyle = BorderStyle.Fixed3D;
            datagridview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            datagridview.GridColor = Color.Gray;
            datagridview.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            datagridview.DefaultCellStyle.SelectionForeColor = Color.White;
            ReverseColumnsOrder(datagridview);
        }
        private void AdminSelling_Load(object sender, EventArgs e)
        {

            // Add columns to the DataGridView if not already added
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("ProductID", "کۆدی کاڵا");
                dataGridView1.Columns.Add("ProductName", "ناوی کاڵا");
                dataGridView1.Columns.Add("Quantity", "دانە");
                dataGridView1.Columns.Add("UnitPrice", "نرخی دانە");
                dataGridView1.Columns.Add("TotalPrice", "کۆی گشتی");
            }
            style(dataGridView1);
            style(dataGridView2);





            try
            {
                // Populate Product ComboBox
                string productQuery = "SELECT ProductID, ProductName FROM Product";
                DataTable productData = db.GetDataTable(productQuery);

                if (productData.Rows.Count > 0)
                {
                    ProductSelection.DataSource = productData;
                    ProductSelection.DisplayMember = "ProductName";
                    ProductSelection.ValueMember = "ProductID";
                    ProductSelection.SelectedIndex = -1; // Clear selection initially
                }
                else
                {
                    MessageBox.Show("!هیچ کاڵایەک لە کۆگادا بوونی نییە", "ئاگادارکردنەوە", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Populate Customer ComboBox
                string customerQuery = "SELECT CustomerID, CustomerName FROM Customer";
                DataTable customerData = db.GetDataTable(customerQuery);

                if (customerData.Rows.Count > 0)
                {
                    comboBox1.DataSource = customerData;
                    comboBox1.DisplayMember = "CustomerName";
                    comboBox1.ValueMember = "CustomerID";
                    comboBox1.SelectedIndex = -1; // Clear selection initially
                }


                // Disable Customer ComboBox initially
                comboBox1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                // Query to fetch Sales data
                string query = "SELECT SaleID, SaleDate, UserAccountID, TotalAmount FROM Sales";

                // Fetch data using your database class
                DataTable salesData = db.GetDataTable(query);

                // Add a Button column to view details if not already added
                if (!dataGridView2.Columns.Contains("ViewDetails"))
                {
                    DataGridViewButtonColumn btnViewDetails = new DataGridViewButtonColumn
                    {
                        Name = "ViewDetails",
                        HeaderText = "Details",
                        Text = "View Details",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView2.Columns.Add(btnViewDetails);
                }
                if (!dataGridView2.Columns.Contains("Print"))
                {
                    DataGridViewButtonColumn btnViewDetails = new DataGridViewButtonColumn
                    {
                        Name = "Print",
                        HeaderText = "چاپکردن",
                        Text = "Print",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView2.Columns.Add(btnViewDetails);
                }

                // Bind data to the DataGridView
                dataGridView2.DataSource = salesData;
                if (dataGridView2.Columns.Contains("SaleID"))
                {
                    dataGridView2.Columns["SaleID"].Visible = false; // Hide the SaleID column from the user
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message);
            }


        }

        private void ReverseColumnsOrder(DataGridView dataGridView)
        {
            int columnCount = dataGridView.Columns.Count;

            for (int i = 0; i < columnCount; i++)
            {
                dataGridView.Columns[i].DisplayIndex = columnCount - 1 - i;
            }
        }



        private void addtolist_Click(object sender, EventArgs e)
        {

            // Ensure a product is selected
            if (ProductSelection.SelectedValue == null)
            {
                MessageBox.Show("Please select a product from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Retrieve the selected product's ID
                int productID = (int)ProductSelection.SelectedValue;

                // Fetch unit price from the database

                string query = "SELECT SellingPrice FROM Product WHERE ProductID = @ProductID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
{
    { "@ProductID", productID }
};

                object result = db.ExecuteScalar(query, parameters);

                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show("Failed to fetch the unit price for the selected product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal unitPrice = Convert.ToDecimal(result);

                // Retrieve the selected product's name
                string productName = ProductSelection.Text;

                // Retrieve quantity from the numeric up/down control
                int quantity = (int)numericUpDown1.Value;

                // Calculate the total price
                decimal totalPrice = unitPrice * quantity;

                // Add the product details to the DataGridView
                dataGridView1.Rows.Add(productID, productName, quantity, unitPrice, totalPrice);

                // Update the total amount
                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void save_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(new DB().ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    if (dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show("Data is Empty!");
                        return;
                    }

                    // Calculate total amount from DataGridView
                    decimal totalAmount = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["TotalPrice"].Value != null)
                        {
                            totalAmount += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                        }
                    }

                    // Validate stock availability for each product
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["ProductID"].Value == null) continue;

                        int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                        // Check stock availability
                        string stockCheckQuery = "SELECT QuantityAvailable FROM Product WHERE ProductID = @ProductID";
                        SqlCommand cmdStockCheck = new SqlCommand(stockCheckQuery, conn, transaction);
                        cmdStockCheck.Parameters.AddWithValue("@ProductID", productID);

                        int availableQuantity = Convert.ToInt32(cmdStockCheck.ExecuteScalar());

                        if (availableQuantity < quantity)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"ژمارەی دیاریکراو بەردەست نییە بۆ کاڵای کۆدی {productID}. ژمارەی بەردەست: {availableQuantity}, داواکراو: {quantity}.",
                                "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Determine customer ID if sale is on credit
                    string customerID = isdebt.Checked ? comboBox1.SelectedValue.ToString() : null;
                    bool isCredit = isdebt.Checked;

                    // Insert into Sales table
                    string insertSaleQuery = "INSERT INTO Sales (CustomerID, SaleDate, IsCredit, UserAccountID, TotalAmount) OUTPUT INSERTED.SaleID VALUES (@CustomerID, @SaleDate, @IsCredit, @UserAccountID, @TotalAmount)";
                    SqlCommand cmdSale = new SqlCommand(insertSaleQuery, conn, transaction);
                    cmdSale.Parameters.AddWithValue("@CustomerID", (object)customerID ?? DBNull.Value);
                    cmdSale.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                    cmdSale.Parameters.AddWithValue("@IsCredit", isCredit);
                    cmdSale.Parameters.AddWithValue("@UserAccountID", currentUserID);
                    cmdSale.Parameters.AddWithValue("@TotalAmount", totalAmount);

                    int saleID = (int)cmdSale.ExecuteScalar();

                    // Insert into SalesDetails for each product
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["ProductID"].Value == null) continue;

                        int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal subtotal = Convert.ToDecimal(row.Cells["TotalPrice"].Value);

                        string insertDetailQuery = "INSERT INTO SalesDetails (SaleID, ProductID, Quantity, Subtotal) VALUES (@SaleID, @ProductID, @Quantity, @Subtotal)";
                        SqlCommand cmdDetail = new SqlCommand(insertDetailQuery, conn, transaction);
                        cmdDetail.Parameters.AddWithValue("@SaleID", saleID);
                        cmdDetail.Parameters.AddWithValue("@ProductID", productID);
                        cmdDetail.Parameters.AddWithValue("@Quantity", quantity);
                        cmdDetail.Parameters.AddWithValue("@Subtotal", subtotal);

                        cmdDetail.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Sale saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear DataGridView1 for new entries
                    dataGridView1.Rows.Clear();
                    UpdateTotalAmount();

                    // Refresh DataGridView2 to reflect the latest Sales data
                    RefreshDataGridView2();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void RefreshDataGridView2()
        {
            try
            {
                string query = "SELECT SaleID, SaleDate, UserAccountID, TotalAmount FROM Sales";

                // Fetch updated sales data
                DataTable salesData = db.GetDataTable(query);

                // Rebind data to DataGridView2
                dataGridView2.DataSource = salesData;

                if (dataGridView2.Columns.Contains("SaleID"))
                {
                    dataGridView2.Columns["SaleID"].Visible = false; // Hide the SaleID column from the user
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void isdebt_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = isdebt.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            isdebt.Checked = false;
            comboBox1.Enabled = false;
            textBox1.Text = "0";
            numericUpDown1.Value = 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "ViewDetails")
            {
                try
                {
                    // Get the SaleID of the selected row
                    int saleID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["SaleID"].Value);

                    // Open the popup form
                    FormSaleDetails detailsForm = new FormSaleDetails(saleID);
                    detailsForm.ShowDialog(); // Use ShowDialog for modal behavior
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening sale details: " + ex.Message);
                }
            }
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "Print")
            {
                try
                {
                    MessageBox.Show("Printed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening sale details: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the start and end dates, stripping the time portion
                DateTime startDate = dateTimePicker1.Value.Date;
                DateTime endDate = dateTimePicker2.Value.Date;


                // Query to fetch sales between the selected dates
                string query = "SELECT SaleID, SaleDate, UserAccountID, TotalAmount FROM Sales WHERE SaleDate BETWEEN @StartDate AND @EndDate";

                // Prepare parameters for the query
                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@StartDate", startDate },
            { "@EndDate", endDate }
        };

                // Fetch data from the database
                DataTable salesData = db.GetDataTableParam(query, parameters);

                // Bind the fetched data to the DataGridView
                dataGridView2.DataSource = salesData;

                // Check if no rows were returned
                if (salesData.Rows.Count == 0)
                {
                    MessageBox.Show("No sales found for the selected date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and display error messages
                MessageBox.Show("Error fetching sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductSelection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
