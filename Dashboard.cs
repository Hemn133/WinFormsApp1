using Microsoft.IdentityModel.Tokens;
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
    public partial class AdminDashboard : Form
    {



        public AdminDashboard()
        {
            InitializeComponent();



        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            DB db = new DB(); // Create an instance of the DB class
            string query = "SELECT * FROM Product"; // Replace with your actual query

            // Retrieve data using the DB class
            DataTable dataTable = db.GetDataTable(query);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable; // Replace 'dataGridView1' with the name of your DataGridView

            dataGridView1.Columns["ProductID"].Visible = false;
            dataGridView1.Columns["QuantityAvailable"].HeaderText = "دانە";
            dataGridView1.Columns["ProductName"].HeaderText = "ناوی کاڵا";
            dataGridView1.Columns["PurchasePrice"].HeaderText = "نرخی کڕین";
            dataGridView1.Columns["SellingPrice"].HeaderText = "نرخی فرۆشتن";
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("NRT Bold", 12, FontStyle.Regular); // Adjust size if needed
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal; // Set background color to teal
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Set text color to white for better contrast
            dataGridView1.AllowUserToAddRows = false;


            dataGridView1.EnableHeadersVisualStyles = false;
            ReverseColumnsOrder(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ReverseColumnsOrder(DataGridView dataGridView)
        {
            int columnCount = dataGridView.Columns.Count;

            for (int i = 0; i < columnCount; i++)
            {
                dataGridView.Columns[i].DisplayIndex = columnCount - 1 - i;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            PurchasePrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            SalePrice.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Quantity.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            string productName = ProductName.Text.Trim();
            string purchasePrice = PurchasePrice.Text.Trim();
            string salePrice = SalePrice.Text.Trim();
            string quantity = Quantity.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(productName) ||
                string.IsNullOrEmpty(purchasePrice) ||
                string.IsNullOrEmpty(salePrice) ||
                string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("تکایە زانیاری کاڵای نوێ دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize the DB class
            DB db = new DB();

            // Define the table name and columns
            string tableName = "Product";
            string[] columns = { "ProductName", "PurchasePrice", "SellingPrice", "QuantityAvailable" };
            string[] values = { productName, purchasePrice, salePrice, quantity };

            // Call the CreateByParameters method
            try
            {
                db.CreateByParameters(tableName, columns, values);
                MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ProductName.Clear();
                PurchasePrice.Clear();
                SalePrice.Clear();
                Quantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string productName = ProductName.Text.Trim();
            string purchasePrice = PurchasePrice.Text.Trim();
            string salePrice = SalePrice.Text.Trim();
            string quantity = Quantity.Text.Trim();

            if (string.IsNullOrEmpty(productName) ||
                string.IsNullOrEmpty(purchasePrice) ||
                string.IsNullOrEmpty(salePrice) ||
                string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("تکایە زانیاری کاڵای نوێ دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DB db = new DB();

            string query = "DELETE FROM Product WHERE ProductName = '" + ProductName.Text + "'";


            db.Execute(query);
            MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void button9_Click(object sender, EventArgs e)
        {
            string productName = ProductName.Text.Trim();
            string purchasePrice = PurchasePrice.Text.Trim();
            string salePrice = SalePrice.Text.Trim();
            string quantity = Quantity.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(productName) ||
                string.IsNullOrEmpty(purchasePrice) ||
                string.IsNullOrEmpty(salePrice) ||
                string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("تکایە کاڵا دیاری بکە", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DB db = new DB();

            string query = "UPDATE Product SET ProductName = '" + productName + "', PurchasePrice = '" + purchasePrice + "', SellingPrice = '" + salePrice + "', QuantityAvailable = '" +quantity + "'";

            db.Execute(query);
            MessageBox.Show("سەرکەوتوو بوو!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

