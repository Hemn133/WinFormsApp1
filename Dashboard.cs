using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
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
        private string _userRole;

        public AdminDashboard(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;
        }
        private void LoadUserControl(UserControl newControl)
        {
            // Clear any existing controls in the panel
            panel1.Controls.Clear();

            // Set the new UserControl to fill the panel
            newControl.Dock = DockStyle.Fill;

            // Add the UserControl to the panel
            panel1.Controls.Add(newControl);
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            AdjustUIForRole();
            AdminSelling categoryAControl = new AdminSelling();
            LoadUserControl(categoryAControl);
        }
        private void AdjustUIForRole()
        {
            if (_userRole == "Admin")
            {
                // Admin has full access
                
            }
            else if (_userRole == "Employee")
            {
                // Employee has limited access
                
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

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductAdmin categoryAControl = new ProductAdmin();

            // Load it into the panel
            LoadUserControl(categoryAControl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSelling adminSelling = new AdminSelling();
            LoadUserControl(adminSelling);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerAdmin customerAControl = new CustomerAdmin();

            LoadUserControl(customerAControl);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DebtSettlementAdmin debtSettlementAdmin = new DebtSettlementAdmin();
            LoadUserControl(debtSettlementAdmin);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExpenseAdmin expenseAControl = new ExpenseAdmin();
            LoadUserControl(expenseAControl);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReturnAdmin returnAdmin = new ReturnAdmin();
            LoadUserControl(returnAdmin);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminReport adminReport = new AdminReport();
            LoadUserControl(adminReport);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "دڵنیایت لە چوونەدەرەوە؟?",
       "چوونەدەرەوە",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Open the login form
                Login loginForm = new Login();
                loginForm.Show();

                // Close the current dashboard form
                this.Close();
            }
        }
    }
}

