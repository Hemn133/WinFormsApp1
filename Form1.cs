using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        private DB dB;
        //?hello
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
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string role = Role.Text;
            string password = Password.Text;

            if (string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("تکایە ناو و وشەی نهێنی داخڵ بکە.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string userRole = AuthenticateUser(role, password);

                if (!string.IsNullOrEmpty(userRole))
                {


                    AdminDashboard adminDashboard = new AdminDashboard(userRole);
                    adminDashboard.Show();

                    this.Hide(); // Hide the login form
                }
                else
                {
                    MessageBox.Show("ناو یان وشەی نهێنی هەڵەیە", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                Password.UseSystemPasswordChar = true;
            }
            else { Password.UseSystemPasswordChar = false; }


        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = true;  // Prevents beep sound
                e.SuppressKeyPress = true;
            }
        }
    }
}