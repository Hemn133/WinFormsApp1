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
    public partial class FormSaleDetails : Form
    {
        private int saleID; // The SaleID to filter the details
        private DB db; // Instance of your DB class

        public FormSaleDetails(int saleID)
        {
            InitializeComponent();
            this.saleID = saleID;
            db = new DB(); // Initialize the DB class
        }

        private void style(DataGridView datagridview)
        {
            datagridview.ColumnHeadersDefaultCellStyle.Font = new Font("NRT Bold", 12, FontStyle.Regular);
            datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
            datagridview.RowHeadersVisible = false;
        }

        private void ReverseColumnsOrder(DataGridView dataGridView)
        {
            int columnCount = dataGridView.Columns.Count;
            for (int i = 0; i < columnCount; i++)
            {
                dataGridView.Columns[i].DisplayIndex = columnCount - 1 - i;
            }
        }

        private void FormSaleDetails_Load(object sender, EventArgs e)
        {
            style(dataGridViewSaleDetails);

            try
            {
                // Query to fetch Sale details with joins
                string query = @"
                    SELECT 
                        P.ProductName AS [ناوی کاڵا], 
                        SD.Quantity AS [دانە], 
                        SD.Subtotal AS [نرخ], 
                        U.Username AS [فرۆشراوە لە لایەن],  
                        CASE 
                            WHEN S.IsCredit = 1 THEN N'قەرز' 
                            ELSE N'کاش' 
                        END AS [جۆری پارەدان],
                        CASE 
                            WHEN C.CustomerName IS NOT NULL THEN C.CustomerName
                            ELSE '-'
                        END AS [ناوی خاوەن قەرز]
                    FROM Sales S
                    INNER JOIN SalesDetails SD ON S.SaleID = SD.SaleID
                    INNER JOIN Product P ON SD.ProductID = P.ProductID
                    INNER JOIN UserAccount U ON S.UserAccountID = U.UserAccountID
                    LEFT JOIN Customer C ON S.CustomerID = C.CustomerID
                    WHERE S.SaleID = @SaleID";

                // Prepare the parameters
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@SaleID", saleID }
                };

                // Fetch data from the database
                DataTable salesDetailsData = db.GetDataTableParam(query, parameters);

                // Bind the data to the DataGridView
                dataGridViewSaleDetails.DataSource = salesDetailsData;
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Error loading sale details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}