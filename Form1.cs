using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        private DB dB;

        public Login()
        {
            InitializeComponent();
            dB = new DB(); // Initialize the database connection
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string role = Role.Text;
            string password = Password.Text;

            if (string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Role and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string userRole = AuthenticateUser(role, password);

                if (!string.IsNullOrEmpty(userRole))
                {
                    MessageBox.Show("Login Successful!");

                    // Redirect to the appropriate dashboard based on the role
                    if (userRole == "Admin")
                    {
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.Show();
                    }
                    else if (userRole == "Employee")
                    {
                        EmployeeDashboard employeeDashboard = new EmployeeDashboard();
                        employeeDashboard.Show();
                    }

                    this.Hide(); // Hide the login form
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Password.Clear();
                    Password.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string AuthenticateUser(string role, string password)
        {
            // Updated query to fetch the Role
            string query = "SELECT Role FROM UserAccount WHERE Role = @Role AND Password = @Password";

            try
            {
                using (SqlConnection conn = new SqlConnection(dB.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString(); // Return the role (e.g., "Admin" or "Employee")
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database error during authentication: " + ex.Message);
            }

            return null; // Return null if authentication fails
        }
    }
}