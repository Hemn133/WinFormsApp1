using System;
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
    public partial class AdminReport : UserControl
    {
        private string _userrole;
        public AdminReport(string userrole)
        {
            InitializeComponent();
            _userrole = userrole;
        }
        DB db = new DB();
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime startDate = StartDatePicker.Value.Date;
            DateTime endDate = EndDatePicker.Value.Date;

            // Query for daily data
            string dailyQuery = @"
       WITH DateTable AS (
    SELECT @StartDate AS [Date]
    UNION ALL
    SELECT DATEADD(DAY, 1, [Date])
    FROM DateTable
    WHERE [Date] < @EndDate
)

SELECT 
    dt.[Date],
    SUM(CASE WHEN s.IsCredit = 0 THEN s.TotalAmount ELSE 0 END) AS CashSales,
    SUM(CASE WHEN s.IsCredit = 1 THEN s.TotalAmount ELSE 0 END) AS DebtSales,
    ISNULL(ds.TotalDebtSettled, 0) AS DebtSettlements,
    ISNULL(e.TotalExpenses, 0) AS Expenses
FROM DateTable dt
LEFT JOIN Sales s ON CONVERT(DATE, s.SaleDate) = dt.[Date]
LEFT JOIN (
    SELECT 
        CONVERT(DATE, PaymentDate) AS PaymentDate, 
        SUM(AmountPaid) AS TotalDebtSettled
    FROM DebtSettlement
    GROUP BY CONVERT(DATE, PaymentDate)
) ds ON ds.PaymentDate = dt.[Date]
LEFT JOIN (
    SELECT 
        CONVERT(DATE, ExpenseDate) AS ExpenseDate, 
        SUM(Amount) AS TotalExpenses
    FROM Expenses
    GROUP BY CONVERT(DATE, ExpenseDate)
) e ON e.ExpenseDate = dt.[Date]
WHERE dt.[Date] BETWEEN @StartDate AND @EndDate
GROUP BY dt.[Date], ds.TotalDebtSettled, e.TotalExpenses
ORDER BY dt.[Date];
";

            DataTable dailyData = ExecuteQueryToDataTable(dailyQuery, new Dictionary<string, object>
    {
        { "@StartDate", startDate },
        { "@EndDate", endDate }
    });
            dataGridViewReports.DataSource = dailyData;

            // Change column names
            if (dataGridViewReports.Columns["Date"] != null)
                dataGridViewReports.Columns["Date"].HeaderText = "بەروار";

            if (dataGridViewReports.Columns["CashSales"] != null)
                dataGridViewReports.Columns["CashSales"].HeaderText = "فرۆشراو(کاش)";

            if (dataGridViewReports.Columns["DebtSales"] != null)
                dataGridViewReports.Columns["DebtSales"].HeaderText = "فرۆشراو(قەرز)";

            if (dataGridViewReports.Columns["DebtSettlements"] != null)
                dataGridViewReports.Columns["DebtSettlements"].HeaderText = "بڕی قەرزی گەڕاوە";

            if (dataGridViewReports.Columns["Expenses"] != null)
                dataGridViewReports.Columns["Expenses"].HeaderText = "بڕی خەرجی";

            if (dataGridViewReports.Columns["Date"] != null)
                dataGridViewReports.Columns["Date"].DisplayIndex = 4; // Last column

            if (dataGridViewReports.Columns["CashSales"] != null)
                dataGridViewReports.Columns["CashSales"].DisplayIndex = 3;

            if (dataGridViewReports.Columns["DebtSales"] != null)
                dataGridViewReports.Columns["DebtSales"].DisplayIndex = 2;

            if (dataGridViewReports.Columns["DebtSettlements"] != null)
                dataGridViewReports.Columns["DebtSettlements"].DisplayIndex = 1;

            if (dataGridViewReports.Columns["Expenses"] != null)
                dataGridViewReports.Columns["Expenses"].DisplayIndex = 0; // First column

            // Query for totals
            string totalsQuery = @"
        SELECT 
    ISNULL(SUM(CASE WHEN s.IsCredit = 0 THEN s.TotalAmount ELSE 0 END), 0) AS TotalCashSales,
    ISNULL(SUM(CASE WHEN s.IsCredit = 1 THEN s.TotalAmount ELSE 0 END), 0) AS TotalDebtSales,
    ISNULL(SUM(ds.TotalDebtSettled), 0) AS TotalDebtSettlements,
    ISNULL(
        (
            SELECT ISNULL(SUM(Amount), 0)
            FROM Expenses
            WHERE CONVERT(DATE, ExpenseDate) BETWEEN @StartDate AND @EndDate
        ), 0
    ) AS TotalExpenses
FROM Sales s
LEFT JOIN (
    SELECT 
        CONVERT(DATE, PaymentDate) AS PaymentDate, 
        SUM(AmountPaid) AS TotalDebtSettled
    FROM DebtSettlement
    WHERE PaymentDate BETWEEN @StartDate AND @EndDate
    GROUP BY CONVERT(DATE, PaymentDate)
) ds ON CONVERT(DATE, s.SaleDate) = ds.PaymentDate
WHERE s.SaleDate BETWEEN @StartDate AND @EndDate;
";

            DataTable totalsData = ExecuteQueryToDataTable(totalsQuery, new Dictionary<string, object>
    {
        { "@StartDate", startDate },
        { "@EndDate", endDate }
    }



            );

            // Update summary fields
            if (totalsData.Rows.Count > 0)
            {
                DataRow row = totalsData.Rows[0];
                txtTotalCashSales.Text = row["TotalCashSales"].ToString();
                txtTotalExpenses.Text = row["TotalExpenses"].ToString();
                txtTotalDebtSales.Text = row["TotalDebtSales"].ToString();
                txtTotalDebtSettlements.Text = row["TotalDebtSettlements"].ToString();

                if (row["TotalCashSales"] == null || row["TotalDebtSettlements"] == null)
                {
                    decimal netTotal = Convert.ToDecimal(row["TotalExpenses"]);
                    txtNetTotal.Text = netTotal.ToString("N0"); // Show as whole number with thousands separator
                }
                else
                {
                    decimal netTotal = Convert.ToDecimal(row["TotalCashSales"]) +
                                       Convert.ToDecimal(row["TotalDebtSettlements"]) -
                                       Convert.ToDecimal(row["TotalExpenses"]);
                    txtNetTotal.Text = netTotal.ToString("N0"); // Show as whole number with thousands separator
                }
            }
        }

        private DataTable ExecuteQueryToDataTable(string query, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Pharmacy;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader); // Fill DataTable
                    }
                }
            }

            return dataTable;
        }

        private void AdminReport_Load(object sender, EventArgs e)
        {


            if (_userrole == "Employee")
            {

                StartDatePicker.Enabled = false;
                EndDatePicker.Enabled = false;

            }
           




            style(dataGridViewReports);
            ReverseColumnsOrder(dataGridViewReports);


        }



        private void style(DataGridView datagridview)
        {
            ReverseColumnsOrder(datagridview);
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

        private void txtTotalExpenses_TextChanged(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Remove any existing formatting
                string unformattedText = textBox.Text.Replace(",", "");

                if (decimal.TryParse(unformattedText, out decimal value))
                {
                    // Format the value with thousand separators
                    textBox.Text = value.ToString("N0");
                    textBox.SelectionStart = textBox.Text.Length; // Maintain caret position
                }
            }
        }

        private void dataGridViewReports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewReports.Columns[e.ColumnIndex].Name == "Expenses" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Format the value as a thousand separator
                    e.Value = value.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
            if (dataGridViewReports.Columns[e.ColumnIndex].Name == "CashSales" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Format the value as a thousand separator
                    e.Value = value.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
            if (dataGridViewReports.Columns[e.ColumnIndex].Name == "DebtSales" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Format the value as a thousand separator
                    e.Value = value.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
            if (dataGridViewReports.Columns[e.ColumnIndex].Name == "DebtSettlements" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Format the value as a thousand separator
                    e.Value = value.ToString("N0");
                    e.FormattingApplied = true;
                }
            }



        }

        private void txtTotalCashSales_TextChanged(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Remove any existing formatting
                string unformattedText = textBox.Text.Replace(",", "");

                if (decimal.TryParse(unformattedText, out decimal value))
                {
                    // Format the value with thousand separators
                    textBox.Text = value.ToString("N0");
                    textBox.SelectionStart = textBox.Text.Length; // Maintain caret position
                }
            }
        }

        private void txtTotalDebtSales_TextChanged(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Remove any existing formatting
                string unformattedText = textBox.Text.Replace(",", "");

                if (decimal.TryParse(unformattedText, out decimal value))
                {
                    // Format the value with thousand separators
                    textBox.Text = value.ToString("N0");
                    textBox.SelectionStart = textBox.Text.Length; // Maintain caret position
                }
            }
        }

        private void txtTotalDebtSettlements_TextChanged(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Remove any existing formatting
                string unformattedText = textBox.Text.Replace(",", "");

                if (decimal.TryParse(unformattedText, out decimal value))
                {
                    // Format the value with thousand separators
                    textBox.Text = value.ToString("N0");
                    textBox.SelectionStart = textBox.Text.Length; // Maintain caret position
                }
            }
        }

        private void txtNetTotal_TextChanged(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Remove any existing formatting
                string unformattedText = textBox.Text.Replace(",", "");

                if (decimal.TryParse(unformattedText, out decimal value))
                {
                    // Format the value with thousand separators
                    textBox.Text = value.ToString("N0");
                    textBox.SelectionStart = textBox.Text.Length; // Maintain caret position
                }
            }
        }
    }
}
