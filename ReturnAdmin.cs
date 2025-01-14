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
    public partial class ReturnAdmin : UserControl
    {
        public ReturnAdmin()
        {
            InitializeComponent();
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

        private void ReverseColumnsOrder(DataGridView dataGridView)
        {
            int columnCount = dataGridView.Columns.Count;

            for (int i = 0; i < columnCount; i++)
            {
                dataGridView.Columns[i].DisplayIndex = columnCount - 1 - i;
            }
        }

        private void ReturnAdmin_Load(object sender, EventArgs e)
        {
            style(dataGridView1);
            style(dataGridView2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ExpenseAmount.Text, out int saleId))
            {
                LoadSaleDetails(saleId);
            }
            else
            {
                MessageBox.Show("ئەم کۆدە بوونی نییە.");
            }
        }

        private void ProcessReturn(int saleId, string productName, int returnQuantity)
        {
            // Get ProductID based on ProductName
            string queryProductID = "SELECT ProductID FROM Product WHERE ProductName = @ProductName";
            Dictionary<string, object> parametersProduct = new Dictionary<string, object>
    {
        { "@ProductName", productName }
    };

            DB db = new DB();
            object productIdObj = db.ExecuteScalar(queryProductID, parametersProduct);

            if (productIdObj == null)
            {
                MessageBox.Show("کاڵا نەدۆزرایەوە.");
                return;
            }

            int productId = Convert.ToInt32(productIdObj);

            // Update the SaleDetails table for the return
            string updateQuery = @"
        UPDATE SaleDetails
        SET ReturnedQuantity = ReturnedQuantity + @ReturnQuantity
        WHERE SaleID = @SaleID AND ProductID = @ProductID";

            Dictionary<string, object> updateParameters = new Dictionary<string, object>
    {
        { "@ReturnQuantity", returnQuantity },
        { "@SaleID", saleId },
        { "@ProductID", productId }
    };

            db.ExecuteWithParameters(updateQuery, updateParameters);

            MessageBox.Show("گەڕانەوەی کاڵا سەرکەوتوبوو");

            // Reload the updated sale details
            LoadSaleDetails(saleId);

            // Check if all products are fully returned
            string checkQuery = @"
        SELECT SUM(Quantity - ReturnedQuantity) AS RemainingQuantity
        FROM SaleDetails
        WHERE SaleID = @SaleID";

            Dictionary<string, object> checkParameters = new Dictionary<string, object>
    {
        { "@SaleID", saleId }
    };

            object remainingQuantityObj = db.ExecuteScalar(checkQuery, checkParameters);
            int remainingQuantity = remainingQuantityObj != null ? Convert.ToInt32(remainingQuantityObj) : 0;

            if (remainingQuantity == 0)
            {
                // Mark Sale as fully returned
                string markReturnedQuery = "UPDATE Sales SET IsReturned = 1 WHERE SaleID = @SaleID";
                db.ExecuteWithParameters(markReturnedQuery, checkParameters);
                MessageBox.Show("گەڕانەوەی پسوڵە سەرکەوتوبوو.");
            }
        }




        private void LoadSaleDetails(int saleId)
        {
            string query = @"
        SELECT sd.ProductID, p.ProductName, sd.Quantity, sd.ReturnedQuantity 
        FROM SalesDetails sd
        JOIN Product p ON sd.ProductID = p.ProductID
        WHERE sd.SaleID = @SaleID";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@SaleID", saleId }
    };

            DB db = new DB();
            DataTable saleDetails = db.GetDataTableParam(query, parameters);

            if (saleDetails.Rows.Count > 0)
            {
                // Bind to DataGridView
                dataGridView1.DataSource = saleDetails;

                // Populate ComboBox with product names
                ProductSelection.Items.Clear();
                foreach (DataRow row in saleDetails.Rows)
                {
                    ProductSelection.Items.Add(row["ProductName"].ToString());
                }
            }
            else
            {
                MessageBox.Show("هێچ پسوڵەیەک نەدۆزرایەوە.");
            }
        }

        private void addtolist_Click(object sender, EventArgs e)
        {

            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.Columns.Add("ProductName", "Product Name");
                dataGridView2.Columns.Add("Quantity", "Quantity");
            }
            // Get the selected product and quantity
            string selectedProduct = ProductSelection.SelectedItem?.ToString();
            int returnQuantity = (int)numericUpDown1.Value;

            // Validate product selection
            if (string.IsNullOrEmpty(selectedProduct))
            {
                MessageBox.Show("تکایە کاڵا دیاری بکە.");
                return;
            }

            // Validate quantity
            if (returnQuantity <= 0)
            {
                MessageBox.Show("تکایە ژمارەیەکی دروست دیاری بکە گەورەتر لە 0.");
                return;
            }

            // Get the available quantity of the selected product from DataGridView 1
            int availableQuantity = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ProductName"].Value.ToString() == selectedProduct)
                {
                    availableQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    break;
                }
            }

            if (returnQuantity > availableQuantity)
            {
                MessageBox.Show("ژمارەی کاڵای گەڕاوە زیاترە لە فرۆشراو.");
                return;
            }

            // Check if the product already exists in DataGridView 2
            bool productExists = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["ProductName"].Value.ToString() == selectedProduct)
                {
                    // Update the quantity
                    int existingQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = existingQuantity + returnQuantity;
                    productExists = true;
                    break;
                }
            }

            // If the product does not exist, add it as a new row
            if (!productExists)
            {
                dataGridView2.Rows.Add(selectedProduct, returnQuantity);
            }

            MessageBox.Show("کاڵا زیاد کرا بۆ بەشی گەڕانەوە.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("هیچ کاڵایەک نییە لە لیستی گەڕانەوە.");
                return;
            }

            DB db = new DB();

            try
            {
                // Fetch SaleID from the TextBox instead of DataGridView1
                if (string.IsNullOrWhiteSpace(ExpenseAmount.Text))
                {
                    MessageBox.Show("کۆدی پسوڵە نابێت بەتاڵبێت.");
                    return;
                }

                int saleID;
                if (!int.TryParse(ExpenseAmount.Text, out saleID))
                {
                    MessageBox.Show("کۆدی پسوڵە هەڵەیە.");
                    return;
                }

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    string productName = row.Cells["ProductName"].Value.ToString();
                    int returnQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    // Update the SaleDetails table
                    string updateSaleDetailsQuery = @"
                UPDATE SalesDetails 
                SET Quantity = Quantity - @ReturnQuantity 
                WHERE SaleID = @SaleID AND ProductName = @ProductName";
                    var saleDetailsParams = new Dictionary<string, object>
            {
                { "@ReturnQuantity", returnQuantity },
                { "@SaleID", saleID },
                { "@ProductName", productName }
            };
                    db.ExecuteWithParameters(updateSaleDetailsQuery, saleDetailsParams);

                    // Update the Product table to increase stock
                    string updateStockQuery = "UPDATE Product SET QuantityAvailable = QuantityAvailable + @ReturnQuantity WHERE ProductName = @ProductName";
                    var stockParams = new Dictionary<string, object>
            {
                { "@ReturnQuantity", returnQuantity },
                { "@ProductName", productName }
            };
                    db.ExecuteWithParameters(updateStockQuery, stockParams);
                }

                MessageBox.Show("کاڵا دیاریکراوەکان بە سەرکەوتووی گەڕانەوە.");
                dataGridView2.Rows.Clear(); // Clear the return list after processing
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the return: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the SaleID from DataGridView1
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("هیچ پسوڵەیەک نییە بۆ گەڕاندنەوە.");
                return;
            }

            int saleID = Convert.ToInt32(dataGridView1.Rows[0].Cells["SaleID"].Value);

            try
            {
                // Update the database to mark the sale as returned
                string updateSaleQuery = "UPDATE Sales SET IsReturned = 1 WHERE SaleID = @SaleID";
                var parameters = new Dictionary<string, object>
        {
            { "@SaleID", saleID }
        };
                DB db = new DB();
                db.ExecuteWithParameters(updateSaleQuery, parameters);

                // Update stock quantities for all products in the sale
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string productName = row.Cells["ProductName"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    string updateStockQuery = "UPDATE Product SET QuantityAvailable = QuantityAvailable + @Quantity WHERE ProductName = @ProductName";
                    var stockParams = new Dictionary<string, object>
            {
                { "@Quantity", quantity },
                { "@ProductName", productName }
            };
                    db.ExecuteWithParameters(updateStockQuery, stockParams);
                }

                MessageBox.Show("پسوڵە بە سەرکەوتووی گەڕایەوە.");
                dataGridView1.Rows.Clear(); // Clear the DataGridView after processing
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while returning the sale: {ex.Message}");
            }
        }
    }

}
