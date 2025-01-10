using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.CodeDom.Compiler;
using System.Data;

namespace WinFormsApp1
{
    internal class DB
    {

        public string ConnectionString = "Data Source=localhost;Initial Catalog=Pharmacy;Integrated Security=True;Trust Server Certificate=True";
        private SqlConnection con;


        public DB() 
        {
        con = new SqlConnection(ConnectionString);
        }


        // Method to execute a query (INSERT, UPDATE, DELETE)
        public void Execute(string query)
        {
            try
            {
                // Open the connection
                con.Open();

                // Prepare and execute the SQL command
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle errors
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Always close the connection
                con.Close();
            }
        }


        // Method to execute a SELECT query and return a SqlDataReader
        public SqlDataReader Select(string query)
        {
            try
            {
                // Open the connection
                con.Open();

                // Prepare the SQL command and execute it
                SqlCommand cmd = new SqlCommand(query, con);
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                // Handle errors
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }


        public void SearchByParameter(string searchValue)
        {
            string query = $"SELECT * FROM  WHERE  LIKE '%{searchValue}%'";
            try
            {
                using (SqlDataReader reader = Select(query))
                {
                    while (reader != null && reader.Read())
                    {
                        // Print or process the result
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)}\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during search: " + ex.Message);
            }
        }


        public void CreateByParameters(string tableName, string[] columns, string[] values)
        {
            if (columns.Length != values.Length)
            {
                Console.WriteLine("Error: Columns and values count mismatch.");
                return;
            }

            string columnsString = string.Join(", ", columns);
            string valuesString = string.Join(", ", values.Select(v => int.TryParse(v, out _) || decimal.TryParse(v, out _) ? v : $"'{v}'"));
            string query = $"INSERT INTO {tableName} ({columnsString}) VALUES ({valuesString})";

            try
            {
                Execute(query);
                Console.WriteLine("Record inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during insertion: " + ex.Message);
            }
        }


        public void DeleteById(string tableName, string idColumn, int id)
        {
            string query = $"DELETE FROM {tableName} WHERE {idColumn} = {id}";

            try
            {
                Execute(query);
                Console.WriteLine("Record deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during deletion: " + ex.Message);
            }
        }



        public DataTable GetDataTable(string query, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add the parameters to the command
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Fill the DataTable with data from the query
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTable;
        }






        public DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    // Fill the DataTable with data from the query
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTable;
        }

        public bool DoesProductExist(string productName)
        {
            string query = "SELECT COUNT(*) FROM Product WHERE ProductName = @ProductName";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Returns true if the product exists, false otherwise
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public void ExecuteWithParameters(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}

