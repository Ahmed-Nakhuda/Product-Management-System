using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagementSystem
{
    public partial class SearchForm : Form
    {
        private Home parentForm;
        private SqlConnection connection;
  

        public SearchForm(Home parent, SqlConnection connection)
        {
            InitializeComponent();
            parentForm = parent;
            this.connection = connection;
        }


        /// <summary>
        /// If description is not empty search by description 
        /// otherwise search by product ID
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string description = searchTextBox.Text;

            if (description != "")
            {
                string query = "SELECT * FROM Products WHERE description LIKE '%" + description + "%'";

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

                            // Display the results in the dataGridView
                            dataGridView1.DataSource = dataTable;
                            dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
                            dataGridView1.ReadOnly = true;

                            // clear textbox
                            searchTextBox.Text = ""; 
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

                // Update the home form
                parentForm.ShowData(query);
                parentForm.RefreshDataGrid();
            }
            else
            {
                decimal id = idNumeric.Value;
                string query = "SELECT * FROM Products WHERE product_id LIKE '%" + id + "%'";
 
                try
                {
                    string searchQuery = "SELECT * FROM Products WHERE product_id LIKE @ID";
                    using (SqlCommand command = new SqlCommand(searchQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", "%" + id + "%");

                        // Execute the SELECT query and retrieve the data using SqlDataReader
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Display the results in the dataGridView
                            dataGridView1.DataSource = dataTable;
                            dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
                            dataGridView1.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Product with id '" + id + "' not found.");
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

                // Update home form
                parentForm.ShowData(query);
                parentForm.RefreshDataGrid();
            }
        }


        /// <summary>
        /// Return to the home form
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            FormUtils.ReturnHome(this);
        }
    }
}
