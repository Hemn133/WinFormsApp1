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
    public partial class receipt : Form
    {
        int _saleID;
        public receipt(int saleID)
        {
            InitializeComponent();
            _saleID = saleID;
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
        }
        private void receipt_Load(object sender, EventArgs e)
        {
            style(dataGridView1);
            DB db = new DB();

            // Query SaleDetails for ProductID, Quantity, and Subtotal
            string detailsQuery = @"
            SELECT ProductID, Quantity, Subtotal 
            FROM SalesDetails 
            WHERE SaleID = @SaleID";

            var detailsParams = new Dictionary<string, object> { { "@SaleID", _saleID } };
            DataTable detailsTable = db.GetDataTable(detailsQuery, detailsParams);

            dataGridView1.DataSource = detailsTable;  // Show data in DataGridView

            // Query TotalAmount from Sales table
            string totalQuery = "SELECT TotalAmount FROM Sales WHERE SaleID = @SaleID";
            object totalObj = db.ExecuteScalar(totalQuery, detailsParams);

            if (totalObj != null)
            {
                decimal totalAmount = Convert.ToDecimal(totalObj);
                label13.Text =totalAmount.ToString();
            }
        }
    }
}
