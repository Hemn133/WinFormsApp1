using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ProductAdmin : UserControl
    {
        private string _userRole;
        private int selectedProductID;

        public ProductAdmin(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;
        }

        private void ProductAdmin_Load(object sender, EventArgs e)
        {
            if (_userRole == "Employee")
                Discount.Visible = false;

            RefreshDataGridView();
        }




        private void RefreshDataGridView()
        {
            DB db = new DB();
            string query = "SELECT * FROM Product";
            DataTable dataTable = db.GetDataTable(query);

            dataGridView1.DataSource = dataTable;

            ConfigureDataGridViewColumns();
            ReverseColumnsOrder(dataGridView1);
        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridView1.Columns["ProductID"].Visible = false;
            dataGridView1.Columns["Discount"].HeaderText = "داشکاندن";
            dataGridView1.Columns["QuantityAvailable"].HeaderText = "دانە";

            if (_userRole == "Admin")
                dataGridView1.Columns["PurchasePrice"].HeaderText = "نرخی کڕین";
            else if (_userRole == "Employee")
                dataGridView1.Columns["PurchasePrice"].Visible = false;

            dataGridView1.Columns["SellingPrice"].HeaderText = "نرخی فرۆشتن";
            dataGridView1.Columns["ProductName"].HeaderText = "ناوی کاڵا";

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("NRT Bold", 12, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.Gray;
        }

        private void ReverseColumnsOrder(DataGridView dataGridView)
        {
            int columnCount = dataGridView.Columns.Count;
            for (int i = 0; i < columnCount; i++)
                dataGridView.Columns[i].DisplayIndex = columnCount - 1 - i;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProductID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProductID"].Value);
            ProductName.Text = dataGridView1.SelectedRows[0].Cells["ProductName"].Value.ToString();
            PurchasePrice.Text = dataGridView1.SelectedRows[0].Cells["PurchasePrice"].Value.ToString();
            SalePrice.Text = dataGridView1.SelectedRows[0].Cells["SellingPrice"].Value.ToString();
            Quantity.Text = dataGridView1.SelectedRows[0].Cells["QuantityAvailable"].Value.ToString();
            Discount.Text = dataGridView1.SelectedRows[0].Cells["Discount"].Value.ToString(); // Retrieve discount
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string productName = ProductName.Text.Trim();
            string purchasePrice = PurchasePrice.Text.Trim();
            string salePrice = SalePrice.Text.Trim();
            string quantity = Quantity.Text.Trim();
            string discount = Discount.Text.Trim(); // Retrieve discount value

            if (string.IsNullOrEmpty(productName) ||
                string.IsNullOrEmpty(purchasePrice) ||
                string.IsNullOrEmpty(salePrice) ||
                string.IsNullOrEmpty(quantity) ||
                string.IsNullOrEmpty(discount)) // Ensure discount is entered
            {
                MessageBox.Show("تکایە زانیاری کاڵای نوێ دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DB db = new DB();

            if (db.DoesProductExist(productName))
            {
                MessageBox.Show("ئەم ناوەی کاڵا پێشتر تۆمار کراوە!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] columns = { "ProductName", "PurchasePrice", "SellingPrice", "QuantityAvailable", "Discount" }; // Include Discount
            string[] values = { productName, purchasePrice, salePrice, quantity, discount }; // Include Discount value

            try
            {
                db.CreateByParameters("Product", columns, values);
                MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProductName.Clear();
                PurchasePrice.Clear();
                SalePrice.Clear();
                Quantity.Clear();
                Discount.Clear(); // Clear Discount
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshDataGridView();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string productName = ProductName.Text.Trim();
            string purchasePrice = PurchasePrice.Text.Trim();
            string salePrice = SalePrice.Text.Trim();
            string quantity = Quantity.Text.Trim();
            string discount = Discount.Text.Trim(); // Retrieve discount value

            if (selectedProductID <= 0 ||
                string.IsNullOrEmpty(productName) ||
                string.IsNullOrEmpty(purchasePrice) ||
                string.IsNullOrEmpty(salePrice) ||
                string.IsNullOrEmpty(quantity) ||
                string.IsNullOrEmpty(discount)) // Ensure discount is entered
            {
                MessageBox.Show("تکایە کاڵا دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DB db = new DB();

            string query = "UPDATE Product SET ProductName = @ProductName, PurchasePrice = @PurchasePrice, SellingPrice = @SellingPrice, QuantityAvailable = @QuantityAvailable, Discount = @Discount WHERE ProductID = @ProductID";
            var parameters = new Dictionary<string, object>
    {
        { "@ProductName", productName },
        { "@PurchasePrice", purchasePrice },
        { "@SellingPrice", salePrice },
        { "@QuantityAvailable", quantity },
        { "@Discount", discount }, // Include Discount
        { "@ProductID", selectedProductID }
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductName.Text.Trim()))
            {
                MessageBox.Show("تکایە کاڵا دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DB db = new DB();

            try
            {
                db.Execute($"DELETE FROM Product WHERE ProductName = '{ProductName.Text}'");
                MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ProductName.Clear();
                PurchasePrice.Clear();
                SalePrice.Clear();
                Quantity.Clear();
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            var columnName = dataGridView1.Columns[e.ColumnIndex]?.Name;

            if (columnName == "PurchasePrice" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
    }









}