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
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void EmployeeDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
