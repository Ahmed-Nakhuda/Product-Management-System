using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace StoreManagementSystem
{
    public partial class DeleteForm : Form
    {
        private Home parentForm;
        private SqlConnection connection;


        public DeleteForm(Home parent, SqlConnection connection)
        {
            InitializeComponent();
            parentForm = parent;
            this.connection = connection;
        }
  

        /// <summary>
        /// Delete a product by ID
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                decimal id = productIDNumeric.Value;
                string deleteQuery = "DELETE FROM Products WHERE product_id = @ProductID";
                string selectAll = "SELECT * FROM Products";
     
                // Create and configure SqlCommand object
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    // Add parameter for product ID
                    command.Parameters.AddWithValue("@ProductID", id);

                    // Execute the DELETE statement
                    int rowsAffected = command.ExecuteNonQuery();
           
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product deleted successfully.");
                        parentForm.RefreshDataGrid();
                    }
                    
                    else
                    {
                        MessageBox.Show("Product with ID " + id + " not found.");
                    }
                    
                }

                // Show all products 
                using (SqlCommand command = new SqlCommand(selectAll, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        dataGridView1.DataSource = dataTable;
                        dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2";
                        dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
                        dataGridView1.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Error displaying all products");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Update parent form
            parentForm.RefreshDataGrid();
        }


        /// <summary>
        /// Search for a product by description 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {  
            string description = searchTextBox.Text;
            string query = "SELECT * FROM Products WHERE description LIKE '%" + description + "%'";
            FormUtils.Search(searchTextBox, connection, dataGridView1);
            parentForm.ShowData(query);
            parentForm.RefreshDataGrid(); 
        }


        /// <summary>
        /// Show all the products when the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteForm_Load(object sender, EventArgs e)
        {
            string selectAllQuery = "SELECT * FROM Products";

            // Create and configure SqlCommand object
            using (SqlCommand command = new SqlCommand(selectAllQuery, connection))
            {
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
                    MessageBox.Show("Error displaying all products");
                }

                reader.Close();
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
