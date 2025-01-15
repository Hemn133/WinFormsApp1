﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class ReturnAdmin : UserControl
    {
        private string _id;
        public ReturnAdmin(string id = "")
        {
            InitializeComponent();
            _id = id;
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
            ExpenseAmount.Text = _id;

            if (!string.IsNullOrWhiteSpace(ExpenseAmount.Text))
            {
                // Trigger button1 click event
                button2.PerformClick();
            }
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

            if (dataGridView2.Columns.Count == 0) // Only set up columns once
            {
                dataGridView2.Columns.Clear();
                dataGridView2.Columns.Add("ProductID", "کۆدی کاڵا");
                dataGridView2.Columns.Add("ProductName", "ناوی کاڵا");
                dataGridView2.Columns.Add("Quantity", "گەڕاوە");
            }

            // Assuming `dataGridView1` contains the sale details
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var selectedProductID = row.Cells["ProductID"].Value;
                    var selectedProductName = row.Cells["ProductName"].Value;
                    var returnQuantity = numericUpDown1.Value; // Use the NumericUpDown value

                    if (selectedProductID != null && selectedProductName != null)
                    {
                        dataGridView2.Rows.Add(selectedProductID, selectedProductName, returnQuantity);
                    }
                    else
                    {
                        MessageBox.Show("The selected row is missing required data.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to add to the return list.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("No items in the return list.");
                return;
            }

            DB db = new DB();

            try
            {
                // Validate SaleID
                if (string.IsNullOrWhiteSpace(ExpenseAmount.Text))
                {
                    MessageBox.Show("Sale ID cannot be empty.");
                    return;
                }

                if (!int.TryParse(ExpenseAmount.Text, out int saleID))
                {
                    MessageBox.Show("Invalid Sale ID. Please enter a valid number.");
                    return;
                }

                decimal totalRefundAmount = 0;

                // Check if the sale is credit
                string checkCreditQuery = "SELECT IsCredit, CustomerID FROM Sales WHERE SaleID = @SaleID";
                var creditParams = new Dictionary<string, object> { { "@SaleID", saleID } };
                var creditData = db.ExecuteReader(checkCreditQuery, creditParams);

                if (!creditData.Read())
                {
                    MessageBox.Show("Sale ID not found.");
                    return;
                }

                bool isCredit = Convert.ToBoolean(creditData["IsCredit"]);
                int customerID = isCredit ? Convert.ToInt32(creditData["CustomerID"]) : 0;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["ProductID"]?.Value == null || row.Cells["Quantity"]?.Value == null)
                    {
                        MessageBox.Show("One or more rows in the return list are missing required information.");
                        return;
                    }

                    int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int returnQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    // Fetch selling price
                    string querySellingPrice = "SELECT SellingPrice FROM Product WHERE ProductID = @ProductID";
                    var priceParams = new Dictionary<string, object> { { "@ProductID", productID } };
                    object sellingPriceObj = db.ExecuteScalar(querySellingPrice, priceParams);

                    if (sellingPriceObj == null)
                    {
                        MessageBox.Show("Selling price not found for the product.");
                        return;
                    }

                    decimal sellingPrice = Convert.ToDecimal(sellingPriceObj);
                    decimal refundAmount = returnQuantity * sellingPrice;
                    totalRefundAmount += refundAmount;

                    // Update the SaleDetails table
                    string updateSaleDetailsQuery = @"
            UPDATE SalesDetails
        SET 
            Quantity = Quantity - @ReturnedQuantity, 
            Subtotal = (Quantity - @ReturnedQuantity) * (SELECT SellingPrice FROM Product WHERE ProductID = @ProductID),
            ReturnedQuantity = ReturnedQuantity + @ReturnedQuantity
        WHERE 
            SaleID = @SaleID AND ProductID = @ProductID;";

                    var saleDetailsParams = new Dictionary<string, object>
        {
            { "@ReturnedQuantity", returnQuantity },
            { "@SaleID", saleID },
            { "@ProductID", productID }
        };

                    db.ExecuteWithParameters(updateSaleDetailsQuery, saleDetailsParams);

                    // Update the Product table to increase stock
                    string updateStockQuery = @"
            UPDATE Product 
            SET QuantityAvailable = QuantityAvailable + @ReturnQuantity 
            WHERE ProductID = @ProductID";

                    var stockParams = new Dictionary<string, object>
        {
            { "@ReturnQuantity", returnQuantity },
            { "@ProductID", productID }
        };

                    db.ExecuteWithParameters(updateStockQuery, stockParams);
                }

                // Update the Sales table for partial returns
                string updateSalesQuery = @"
        UPDATE Sales 
        SET TotalAmount = TotalAmount - @ReducedAmount
        WHERE SaleID = @SaleID";

                var salesParams = new Dictionary<string, object>
    {
        { "@ReducedAmount", totalRefundAmount },
        { "@SaleID", saleID }
    };

                db.ExecuteWithParameters(updateSalesQuery, salesParams);

                // Update the Customer table for credit sales
                if (isCredit)
                {
                    string updateCustomerDebtQuery = @"
            UPDATE Customer
            SET TotalDebt = TotalDebt - @ReducedAmount
            WHERE CustomerID = @CustomerID";

                    var customerDebtParams = new Dictionary<string, object>
        {
            { "@ReducedAmount", totalRefundAmount },
            { "@CustomerID", customerID }
        };

                    db.ExecuteWithParameters(updateCustomerDebtQuery, customerDebtParams);
                }

                MessageBox.Show("The selected items have been returned successfully.");
                dataGridView2.Rows.Clear(); // Clear the return list after processing
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the return: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int saleID = Convert.ToInt32(ExpenseAmount.Text); // Replace with your SaleID input field

            string getSalesDetailsQuery = @"
        SELECT ProductID, Quantity 
        FROM SalesDetails
        WHERE SaleID = @SaleID;";

            string updateSalesDetailsQuery = @"
        UPDATE SalesDetails
        SET 
            ReturnedQuantity = Quantity,
            Quantity = 0,
            Subtotal = 0
        WHERE 
            SaleID = @SaleID;";

            string updateProductStockQuery = @"
        UPDATE Product
        SET 
            QuantityAvailable = QuantityAvailable + @ReturnedQuantity
        WHERE 
            ProductID = @ProductID;";

            string updateSalesQuery = @"
        UPDATE Sales
        SET 
            IsReturned = 1,
TotalAmount=0
        WHERE 
            SaleID = @SaleID;";

            DB db = new DB();

            try
            {
                string getSalesDetailsQueryy = @"
    SELECT SalesDetailID, ProductID, Quantity, Subtotal 
    FROM SalesDetails 
    WHERE SaleID = @SaleID";

                DataTable salesDetails;

                using (SqlDataReader reader = db.ExecuteReader(getSalesDetailsQuery, new Dictionary<string, object>
{
    { "@SaleID", saleID }
}))
                {
                    // Create and populate the DataTable
                    salesDetails = new DataTable();
                    salesDetails.Load(reader);
                }

                // Update Product stock for each item in the Sale
                foreach (DataRow row in salesDetails.Rows)
                {
                    int productID = Convert.ToInt32(row["ProductID"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);

                    db.ExecuteNonQuery(updateProductStockQuery, new Dictionary<string, object>
            {
                { "@ProductID", productID },
                { "@ReturnedQuantity", quantity }
            });
                }

                // Update SalesDetails
                db.ExecuteNonQuery(updateSalesDetailsQuery, new Dictionary<string, object>
        {
            { "@SaleID", saleID }
        });

                // Mark the Sale as Returned
                db.ExecuteNonQuery(updateSalesQuery, new Dictionary<string, object>
        {
            { "@SaleID", saleID }
        });

                MessageBox.Show("Full return processed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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

        private void ProductSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = ProductSelection.SelectedItem.ToString();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ProductName"].Value != null && row.Cells["ProductName"].Value.ToString() == selectedProduct)
                {
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    numericUpDown1.Maximum = quantity > 0 ? quantity : 1; // Prevents setting 0 as the max
                    numericUpDown1.Value = 1; // Reset value to 1 when selection changes
                    break;
                }
            }
        }
    }

}
