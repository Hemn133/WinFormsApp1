using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.CodeDom.Compiler;

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
            string valuesString = string.Join(", ", values.Select(v => $"'{v}'")); // Wrap values with quotes
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



    }
}
