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
    public partial class AdminSelling : UserControl
    {
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

      
        DB db = new DB();

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
                    MessageBox.Show("No products available in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else
                {
                    MessageBox.Show("No customers available in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Disable Customer ComboBox initially
                comboBox1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DB db = new DB();
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
            try
            {
                DB db = new DB();

                // Calculate total amount from DataGridView
                decimal totalAmount = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["TotalPrice"].Value != null)
                    {
                        totalAmount += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                    }
                }

                // Determine customer ID if sale is on credit
                string customerID = isdebt.Checked ? comboBox1.SelectedValue.ToString() : null;
                bool isCredit = isdebt.Checked;

                // Example of current user ID; replace with your actual logic for fetching user ID
                int currentUserID = 1; // Assuming you're fetching this from the logged-in user session

                // Insert into Sales table
                string insertSaleQuery = "INSERT INTO Sales (CustomerID, SaleDate, IsCredit, UserAccountID, TotalAmount) OUTPUT INSERTED.SaleID VALUES (@CustomerID, @SaleDate, @IsCredit, @UserAccountID, @TotalAmount)";
                Dictionary<string, object> saleParams = new Dictionary<string, object>
        {
            { "@CustomerID", (object)customerID ?? DBNull.Value },
            { "@SaleDate", DateTime.Now },
            { "@IsCredit", isCredit },
            { "@UserAccountID", currentUserID },
            { "@TotalAmount", totalAmount } // Pass the calculated total amount
        };
                int saleID = (int)db.ExecuteScalar(insertSaleQuery, saleParams);

                // Insert into SaleDetails table for each product in the DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ProductID"].Value == null) continue; // Skip empty rows

                    int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                    decimal subtotal = Convert.ToDecimal(row.Cells["TotalPrice"].Value);

                    string insertDetailQuery = "INSERT INTO SaleDetails (SaleID, ProductID, Quantity, Subtotal) VALUES (@SaleID, @ProductID, @Quantity, @Subtotal)";
                    Dictionary<string, object> detailParams = new Dictionary<string, object>
            {
                { "@SaleID", saleID },
                { "@ProductID", productID },
                { "@Quantity", quantity },
                { "@Subtotal", subtotal }
            };
                    db.Execute(insertDetailQuery);

                    // Update product quantity in the inventory
                    string updateProductQuery = "UPDATE Product SET Quantity = Quantity - @Quantity WHERE ProductID = @ProductID";
                    Dictionary<string, object> updateParams = new Dictionary<string, object>
            {
                { "@Quantity", quantity },
                { "@ProductID", productID }
            };
                    db.Execute(updateProductQuery);
                }

                // Update customer's total debt if it's a credit sale
                if (isCredit)
                {
                    string updateCustomerDebtQuery = "UPDATE Customer SET TotalDebt = TotalDebt + @TotalAmount WHERE CustomerID = @CustomerID";
                    Dictionary<string, object> debtParams = new Dictionary<string, object>
            {
                { "@TotalAmount", totalAmount },
                { "@CustomerID", customerID }
            };
                    db.Execute(updateCustomerDebtQuery);
                }

                MessageBox.Show("Sale completed successfully!");
                button1.PerformClick(); // Reset form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
            textBox1.Text = "0.00";
            numericUpDown1.Value = 1;
        }
    }
}
