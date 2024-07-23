using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;

namespace StoreManagementSystem
{
    public class FormUtils
    {

        /// <summary>
        /// Method to return back to the home form
        /// </summary>
        /// <param name="currentForm">The form the user  is currently on</param>
        public static void ReturnHome(Form currentForm)
        {
            Home form = new Home();
            form.Show();
            currentForm.Close();
        }

        /// <summary>
        /// Method to redirect to the form the user want to open
        /// </summary>
        /// <param name="currentForm">The home form</param>
        /// <param name="targetForm">The form they want to open</param>
        public static void ShowForm(Form currentForm, Form targetForm)
        {
            targetForm.Show();
            currentForm.Hide();
        }

        /// <summary>
        /// Search for a product
        /// </summary>
        /// <param name="searchTextBox">value the user enters in the textbox</param>
        /// <param name="connection">connection string</param>
        /// <param name="dataGridView1">data grid view</param>
        /// <param name="parentForm">the home form</param>
        public static void Search(TextBox searchTextBox, SqlConnection connection, DataGridView dataGridView1)
        {
            string description = searchTextBox.Text;

            try
            {
                string searchQuery = "SELECT * FROM Products WHERE description LIKE @Description";
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                   
                    command.Parameters.AddWithValue("@Description", "%" + description + "%");

                    // Execute the SELECT query and retrieve the data using SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Display the results in the DataGridView
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2";
                        dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
                        dataGridView1.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product with description '" + description + "' not found.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public static void ShowData(SqlDataAdapter sqlDataAdapter, SqlConnection connection, DataTable dataTable, DataGridView dataGridView1)
        {
            sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Products", connection);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
                
            // Format
            dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
            dataGridView1.ReadOnly = true;
            
        }

    }
}
